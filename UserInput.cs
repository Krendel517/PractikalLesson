using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyCalculator
{
    class UserInput
    {
        private string currentInput;
        private string checkedInput;

        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";

        private string plus = "+";
        private string substruction = "-";
        private string division = "/";
        private string multiplication = "*";
        private string persent = "%";
        public double NumberConv;

        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";

        private string exit = "Exit";
        private string calculatorAgain = "Calculate again";
        private string exitToMainMenu = "Return";

        NumberFormatInfo chekPoint = new NumberFormatInfo()
        {
            NumberDecimalSeparator = "."
        };

        NumberFormatInfo chekComma = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ","
        };


        public string GetUserInput(TypeOfUserInput type)
        {
            if (type == TypeOfUserInput.year)
            {
                GetUserInputYear();
            }

            else if (type == TypeOfUserInput.number)
            {
                GetUserInputNumbAndCommand();
            }

            else if (type == TypeOfUserInput.currency)
            {
                GetUserInputCurrency();
            }

            else if (type == TypeOfUserInput.money)
            {
                GetUserInputMoney();
            }

            else if (type == TypeOfUserInput.simpleNumber)
            {
                GetUserInputSimpleNumb();
            }

            else if (type == TypeOfUserInput.mathematicalActions)
            {
                GetUserInputMathAction();
            }

            return checkedInput;
        }

        private string GetUserInputYear(bool showWarning = true)
        {
            Console.WriteLine("Введите свой год рождения");
            Console.WriteLine("===============================");

            currentInput = Console.ReadLine();

            if (currentInput.All(Char.IsDigit))
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                Console.Clear();
                Console.WriteLine("Значение не корректно, попробуйте ввести нужное значение снова.");
                Console.WriteLine("===============================================================");

                GetUserInputYear();
            }
            return checkedInput;
        }

        private string GetUserInputNumbAndCommand(bool showWarning = true)
        {

            Console.WriteLine("Чтобы выбрать нужный вам калькулятор, введите соответствующую цифру.");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("1. Простой калькулятор");
            Console.WriteLine("2. Калькулятор возраста");
            Console.WriteLine("3. Калькулятор налогов");

            currentInput = Console.ReadLine();

            if (currentInput == firstCalc || currentInput == secCalc || currentInput == thirdCalc)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                Console.Clear();
                Console.WriteLine("Значение не корректно, попробуйте снова.");
                Console.WriteLine("=========================================");

                GetUserInputNumbAndCommand();
            }

            return checkedInput;
        }

        private string GetUserInputCurrency(bool showWarning = true)
        {
            Console.WriteLine("Введите валюту вашего дохода");
            Console.WriteLine("==========================================");//Декоративная часть интерфейса
            Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
            Console.WriteLine("==========================================");//Декоративная часть интерфейса

            currentInput = Console.ReadLine();

            if (currentInput == hryvnia)
            {
                checkedInput = currentInput;
            }

            else if (currentInput == dollar)
            {
                checkedInput = currentInput;
            }

            else if (currentInput == euro)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                Console.Clear();
                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("==========================================");

                GetUserInputCurrency();
            }
            return checkedInput;
        }

        private string GetUserInputMoney(bool showWarning = true)
        {
            currentInput = Console.ReadLine();
            bool isLetter = currentInput.All(Char.IsLetter);

            if (double.TryParse(currentInput, out double number))
            {
                NumberConv = Convert.ToDouble(currentInput);

                checkedInput = currentInput;
            }
            else if (isLetter == false && currentInput.Contains("."))
            {
                if (currentInput.Contains("."))
                {
                    NumberConv = Convert.ToDouble(currentInput, chekPoint);
                }

                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("========================================");

                GetUserInputMoney();
            }
            return checkedInput;
        }

        private string GetUserInputSimpleNumb(bool showWarning = true)
        {
            currentInput = Console.ReadLine();
            bool isLetter = currentInput.All(Char.IsLetter);

            if (double.TryParse(currentInput, out double number))
            {   
                NumberConv = Convert.ToDouble(currentInput);

                checkedInput = currentInput;
            }
            else if (isLetter == false && currentInput.Contains("."))
            {
                if (currentInput.Contains("."))
                {
                    NumberConv = Convert.ToDouble(currentInput, chekPoint);
                }

                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("========================================");

                GetUserInputSimpleNumb();
            }
            return checkedInput;
        }

        private string GetUserInputMathAction(bool showWarning = true)
        {
            currentInput = Console.ReadLine();
            if (currentInput == plus)
            {
                checkedInput = currentInput;
            }
            else if (currentInput == substruction)
            {
                checkedInput = currentInput;
            }
            else if (currentInput == division)
            {
                checkedInput = currentInput;
            }
            else if (currentInput == multiplication)
            {
                checkedInput = currentInput;
            }
            else if (currentInput == persent)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                Console.WriteLine("Значение не верно, попробуйте снова.");
                Console.WriteLine("========================================");

                GetUserInputMathAction();
            }
            return checkedInput;
        }

        private string GetUserInputCommand(bool showWarning = true)
        {
            Console.Clear();

            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите {calculatorAgain}, чтобы посчитать заново.");
            Console.WriteLine($"Введите {exitToMainMenu} чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите {exit}");
            Console.WriteLine("======================================================");

            currentInput = Console.ReadLine();

            if (currentInput == calculatorAgain)
            {
                checkedInput = currentInput;
            }
            else if (currentInput == exit)
            {
                checkedInput = currentInput;
            }
            else if (currentInput == exitToMainMenu)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                Console.Clear();
                Console.WriteLine("Значение некорректно, попробуйте снова");
                GetUserInputCommand();
            }
            return checkedInput;
        }

        string GetUserInput()
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