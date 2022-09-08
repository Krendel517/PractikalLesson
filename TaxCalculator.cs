using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyCalculator
{
    public class TaxCalculator
    {
        UserInput chekInput = new UserInput();
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

        public void TaxCalculate()
        {
            Show();
            ChooseCurrency();
            YearIncome();
            AnswerTax("");
        }

        public void Show()
        {
            Console.WriteLine("Вы выбрали калькулятор дохода, нажмите любую кнопку чтобы приступить к вычисления дохода.");

            Console.ReadKey();
            Console.Clear();
        }

        public void ChooseCurrency()
        {
            Console.WriteLine("Введите валюту вашего дохода");
            Console.WriteLine("_________________________________________");//Декоративная часть интерфейса
            Console.WriteLine(" ");
            Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
            Console.WriteLine("_________________________________________");//Декоративная часть интерфейса

            inputCur = chekInput.GetUserInput(TypeOfUserInput.currency, TypeOfUserInput.money);

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

        public void YearIncome()
        {
            string[] moth = { "январь:", "февраль:", "март:", "апрель:", "май:", "июнь:", "июль:", "август:", "сентябрь:", "октябрь:", "ноябрь:", "декабрь:" };
            string[] monthlySalary = new string[12];
            double[] monthlySalaryInt = new double[12];


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
                Console.WriteLine("Введите ваш доход за " + moth[count]);

                monthlySalary[count] = chekInput.GetUserInput(TypeOfUserInput.money);

                if (monthlySalary[count].Contains("."))
                {
                    monthlySalaryInt[count] = Convert.ToDouble(monthlySalary[count], chekPoint);
                }
                else if (monthlySalary[count].Contains(","))
                {
                    monthlySalaryInt[count] = Convert.ToDouble(monthlySalary[count], chekComma);
                }
                else
                {
                    monthlySalaryInt[count] = Convert.ToDouble(monthlySalary[count]);
                }
            }

            double annualIncome = 0;
            foreach (double annualIncomeInt in monthlySalaryInt)
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
        }

        public void AnswerTax(string hollowString)
        {
            string InputFalse = @"Значение не корректно, попробуйте снова
___________________________________________";

        Console.Clear();
            Console.WriteLine("Вот ваш счет!");
            Console.WriteLine("_________________________________________");
            Console.WriteLine(" ");

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
            Console.WriteLine("_________________________________________");
            Console.WriteLine("");
            Console.WriteLine(hollowString);
            Console.WriteLine("Введите Calculate again, чтобы посчитать заново.");
            Console.WriteLine("Введите Return чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine("Если же вы желаете выйти, введите Exit");

            input = chekInput.GetUserInput(TypeOfUserInput.command);

            if (input == calculatorAgain)
            {
                Console.Clear();
                ChooseCurrency();
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
                AnswerTax(InputFalse);
            }

            Console.ReadKey();

        }
    }
}

