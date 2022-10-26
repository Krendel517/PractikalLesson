using System;
using System.Globalization;

namespace PractikalLesson_1
{
    class TaxCalculator : BaseCalculator
    {
        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";
        string inputCur;
        protected string[] mothStr = { "январь:", "февраль:", "март:", "апрель:", "май:", "июнь:", "июль:", "август:", "сентябрь:", "октябрь:", "ноябрь:", "декабрь:" };
        double[] monthlySalaryDouble = new double[12];
        private string formatMoney = "{0:N}";
        private string valut = "";
        private double singleTax;
        private double taxDeduction;
        double annualIncome = 0;
        private const double minimumWage = 6500;
        double singleSocialContribution = minimumWage * 0.22;
        const double kursDollar = 29.2;
        const double kursEuro = 30.7;
        double sumInHruvnia = 0;

        public TaxCalculator(string name, int id) : base(name, id)
        {
        }
        public override void Show()
        {
            WelcomeMessege();
            ChooseCurreny();
            GetInput();
            Calculate();
            ShowResult();
        }

        private void ChooseCurreny()
        {
            Console.WriteLine("Введите валюту вашего дохода");
            Console.WriteLine("==========================================");//Декоративная часть интерфейса
            Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
            Console.WriteLine("==========================================");//Декоративная часть

            inputCur = userInput.GetUserInput(TypeOfUserInput.currency, TypeOfUserInput.command);

            GlobalVariable.checkedInput = inputCur;
            CheckReturnInput();

            if (inputCur == hryvnia)
            {
                valut = " грн.";
            }
            else if (inputCur == dollar)
            {
                valut = " дол.";
            }
            else if (inputCur == euro)
            {
                valut = " евро.";
            }
        }

        public override void GetInput()
        {
            string[] monthlySalaryStr = new string[12];

            NumberFormatInfo chekPoint = new NumberFormatInfo()
            {
                NumberDecimalSeparator = "."
            };

            NumberFormatInfo chekComma = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ","
            };

            for (int count = 0; count <= 11; count++)
            {
                Console.Clear();
                Console.WriteLine("Введите ваш доход за " + mothStr[count]);
                Console.WriteLine("======================================");

                monthlySalaryStr[count] = userInput.GetUserInput(TypeOfUserInput.money, TypeOfUserInput.command);

                GlobalVariable.checkedInput = monthlySalaryStr[count];
                CheckReturnInput();

                if (monthlySalaryStr[count].Contains("."))
                {
                    monthlySalaryDouble[count] = Convert.ToDouble(monthlySalaryStr[count], chekPoint);
                }
                else if (monthlySalaryStr[count].Contains(","))
                {
                    monthlySalaryDouble[count] = Convert.ToDouble(monthlySalaryStr[count], chekComma);
                }
                else
                {
                    monthlySalaryDouble[count] = Convert.ToDouble(monthlySalaryStr[count]);
                }
            }
        }

        public override void Calculate()
        {
            foreach (double annualIncomeInt in monthlySalaryDouble)
            {
                annualIncome += annualIncomeInt;
            }

            switch (inputCur)
            {
                case hryvnia:
                    sumInHruvnia += annualIncome;
                    break;

                case dollar:
                    sumInHruvnia = annualIncome * kursDollar;
                    break;

                case euro:
                    sumInHruvnia = annualIncome * kursEuro;
                    break;
            }
        }

        public override void ShowResult()
        {
            Console.Clear();
            Console.Write("Ваш годовой доход состовляет:" + formatMoney, annualIncome);
            Console.WriteLine(valut);
            Console.WriteLine("============================================");
            Console.Write("Сумма в гривнах " + formatMoney, sumInHruvnia);
            Console.WriteLine(" грн.");
            singleTax = sumInHruvnia * 0.05;
            Console.Write("Сумма единого налога равна " + formatMoney, singleTax);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого социального взноса равна " + formatMoney, singleSocialContribution);
            Console.WriteLine(" грн.");
            taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;
            Console.Write("Ваша прибыль, за вычетом налогов равна " + formatMoney, taxDeduction);
            Console.WriteLine(" грн.");

            GetCommand();
        }
    }
}

