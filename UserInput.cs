using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class UserInput
    {
        TaxCalculator taxAgain = new TaxCalculator();

        private string currentInput;

        private string chekedInput;
        public string MyProperty
        {
            get { return currentInput; }
            private set { currentInput = value; }
        }


        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";

        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";

        private string exit = "Exit";
        private string calculatorAgain = "Calculate again";
        private string exitToMainMenu = "Return";
        private string InputFalse = @"Значение не корректно, попробуйте снова
___________________________________________";

        public string GetUserInput(TypeOfUserInput type, bool showWarning = true)
        {
            currentInput = Console.ReadLine();

            if (type == TypeOfUserInput.year)
            {
                if (currentInput.All(Char.IsDigit))
                {
                    chekedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, попробуйте ввести нужное значение снова.");
                    Console.WriteLine("===============================================================");

                    Environment.Exit(0);
                }
            }
            if (type == TypeOfUserInput.number)
            {
                if (currentInput == firstCalc || currentInput == secCalc || currentInput == thirdCalc)
                {
                    chekedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, попробуйте снова.");
                    Console.WriteLine("=========================================");

                    MainMenu chooseCalc = new MainMenu();
                    chooseCalc.CalculatorSelection();
                }
            }
            if (type == TypeOfUserInput.currency)
            {
                if (currentInput == hryvnia)
                {
                    chekedInput = currentInput;
                }

                else if (currentInput == dollar)
                {
                    chekedInput = currentInput;
                }

                else if (currentInput == euro)
                {
                    chekedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение некорректно, попробуйте снова");
                    Console.WriteLine("___________________________________________");

                    taxAgain.ChooseCurrency();
                }
            }
            else if (type == TypeOfUserInput.money)
            {
                if (double.TryParse(currentInput, out double number))
                {
                    chekedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение некорректно, попробуйте снова");
                    Console.WriteLine("___________________________________________");

                    taxAgain.YearIncome();
                }
            }
            else if (type == TypeOfUserInput.command)
            {
                if (currentInput == calculatorAgain)
                {
                    chekedInput = currentInput;
                }
                else if (currentInput == exit)
                {
                    chekedInput = currentInput;
                }
                else if (currentInput == exitToMainMenu)
                {
                    chekedInput = currentInput;
                }
                else
                {
                    taxAgain.AnswerTax(InputFalse);
                }
            }
            return currentInput;
        }
        public string GetUserInput()
        {
            currentInput = Console.ReadLine();

            if (currentInput.Contains(""))
            {
                Console.WriteLine("Значение не корректно, введите любую клавишу, чтобы выйти");

                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Ввод успешен, но все же нажмите любую клавишу чтобы выйти :)");

                Console.ReadKey();
                Environment.Exit(0);
            }

            return currentInput;
        }
    }
}