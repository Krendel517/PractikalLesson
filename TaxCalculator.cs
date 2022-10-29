using System;
using System.Globalization;

namespace PractikalLesson_1
{
    class TaxCalculator : BaseCalculator
    {
        public int count;
        public double singleSocialContribution = minimumWage * 0.22;
        public double sumInHruvnia = 0;
        public double[] monthlySalaryDouble = new double[12];
        public string formatMoney = "{0:N}";
        public string valut = "";
        public double singleTax;
        public double taxDeduction;
        public double annualIncome = 0;
        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";
        private string inputCur;
        private const double minimumWage = 6500;
        private const double kursDollar = 29.2;
        private const double kursEuro = 30.7;
        public string[] mothStr = { "январь:", "февраль:", "март:", "апрель:", "май:", "июнь:", "июль:", "август:", "сентябрь:", "октябрь:", "ноябрь:", "декабрь:" };

        TaxCalculatorView taxCalculatorView = new TaxCalculatorView("калькулятор налогов", 3);

        public TaxCalculator(string name, int id) : base(name, id)
        {
        }

        public override void Show()
        {
            taxCalculatorView.WelcomeMessegeView();
            WelcomeMessege();
            ChooseCurreny();
            GetInput();
            Calculate();
            ShowResult();
        }

        private void ChooseCurreny()
        {
            taxCalculatorView.RequestEnterCurrency();
            inputCur = userInput.GetUserInput(TypeOfUserInput.currency, TypeOfUserInput.command);

            GlobalVariable.checkedInput = inputCur;
            taxCalculatorView.ExiFromProgramOrMainMenu();

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

            for (count = 0; count <= 11; count++)
            {
                Console.Clear();
                Console.WriteLine("Введите ваш доход за " + mothStr[count]);
                Console.WriteLine("======================================");

                monthlySalaryStr[count] = userInput.GetUserInput(TypeOfUserInput.money, TypeOfUserInput.command);

                GlobalVariable.checkedInput = monthlySalaryStr[count];
                taxCalculatorView.ExiFromProgramOrMainMenu();

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
            taxCalculatorView.ShowCommand();
            GetCommand();
        }
    }
}

