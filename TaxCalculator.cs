using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class TaxCalculator : BaseCalculator
    {
        UserInput chekInput = new UserInput();
        public TaxCalculator(string name, int id) : base(name, id)
        {
        }

        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";
        string inputCur;

        private string formatMoney = "{0:N}";
        private string valut = "";
        private double singleTax;
        private double taxDeduction;
        private const double minimumWage = 6500;
        double singleSocialContribution = minimumWage * 0.22;
        const double kursDollar = 29.2;
        const double kursEuro = 30.7;
        double sumInHruvnia = 0;

        private string exit = "Exit";
        private string calculatorAgain = "Calculate again";
        private string exitToMainMenu = "Return";
        string input = " ";

        public void Start()
        {
            Show();
            ChooseCurrency();
            CalculateIncome();
            ShowResult();
        }

        private void ChooseCurrency()
        {
            Console.WriteLine("Введите валюту вашего дохода");
            Console.WriteLine("==========================================");//Декоративная часть интерфейса
            Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
            Console.WriteLine("==========================================");//Декоративная часть

            inputCur = chekInput.GetUserInput(TypeOfUserInput.currency);

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

        private void CalculateIncome()
        {
            string[] mothStr = { "январь:", "февраль:", "март:", "апрель:", "май:", "июнь:", "июль:", "август:", "сентябрь:", "октябрь:", "ноябрь:", "декабрь:" };
            string[] monthlySalaryStr = new string[12];
            double[] monthlySalaryDouble = new double[12];


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

                monthlySalaryStr[count] = chekInput.GetUserInput(TypeOfUserInput.money);

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

            double annualIncome = 0;
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

            Console.Clear();
            Console.Write("Ваш годовой доход состовляет:" + formatMoney, annualIncome);
            Console.WriteLine(valut);
            Console.WriteLine("____________________________________________");
            Console.WriteLine("Нажмите любую клавишу, чтобы посмотреть ваш доход в грн.");

            Console.ReadKey();
            Console.Clear();
        }

        private void ShowResult()
        {


            Console.WriteLine("Вот ваш счет!");
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

            ShowCommand();
            input = chekInput.GetUserInput(TypeOfUserInput.command);

            if (input == calculatorAgain)
            {
                Start();
            }
            else if (input == exitToMainMenu)
            {
               ExitToMainMenu();
            }
            else if (input == exit)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("============================================");
                ShowResult();
            }

            Console.ReadKey();
        }
    }
}

