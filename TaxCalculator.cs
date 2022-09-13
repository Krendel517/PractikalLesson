using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCalculator
{
    public class TaxCalculator
    {
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

        public void ShowAllCalculator()
        {
            Show();
            ChooseCurrency();
            CalculateIncome();
            ShowResult();
        }

        public void Show()
        {
            Console.WriteLine("Вы выбрали калькулятор дохода, нажмите любую кнопку чтобы приступить к вычисления дохода.");

            Console.ReadKey();
            Console.Clear();
        }

        public void ChooseCurrency()
        {
            UserInput chekInput = new UserInput();
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

        public void CalculateIncome()
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

                UserInput chekInput = new UserInput();
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

        public void ShowResult()
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
            Console.WriteLine("============================================");
            Console.WriteLine("Введите Calculate again, чтобы посчитать заново.");
            Console.WriteLine("Введите Return чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine("Если же вы желаете выйти, введите Exit");

            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.command);

            if (input == calculatorAgain)
            {
                ShowAllCalculator();
                Console.Clear();
                Console.WriteLine("Введите любую клавишу чтобы приступить к вычисления годового дохода.");
            }
            else if (input == exitToMainMenu)
            {
                MainMenu mainMenu = new MainMenu();

                Console.Clear();
                mainMenu.CalculatorSelection();
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

