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
        public double numberConv;

        NumberFormatInfo chekPoint = new NumberFormatInfo()
        {
            NumberDecimalSeparator = "."
        };

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

        public string GetUserInput(TypeOfUserInput type)
        {
            switch (type)
            {
                case TypeOfUserInput.year:
                    GetUserInputYear();
                    break;

                case TypeOfUserInput.number:
                    GetUserInputNumberCalc();
                    break;

                case TypeOfUserInput.currency:
                    GetUserInputCurrency();
                    break;

                case TypeOfUserInput.money:
                    GetUserInputMoney();
                    break;

                case TypeOfUserInput.simpleNumber:
                    GetUserInputSimpleNumb();
                    break;

                case TypeOfUserInput.mathematicalActions:
                    GetUserInputMathAction();
                    break;

                case TypeOfUserInput.command:
                    GetUserInputCommand();
                    break;
            }

            return checkedInput;
        }

        public string GetUserInputTwoType(TypeOfUserInput firstType, TypeOfUserInput secondType)
        {
            string firstCalc = "1";
            string secCalc = "2";
            string thirdCalc = "3";
            string exit = "Exit";

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
            else if (currentInput == exit)
            {
                checkedInput = currentInput;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Значение не корректно, попробуйте снова.");
                Console.WriteLine("=========================================");

                GetUserInputTwoType(firstType, secondType);
            }

            return checkedInput;
        }

        private string GetUserInputYear(bool showWarning = true)
        {
            Console.WriteLine("Введите свой год рождения");
            Console.WriteLine("===============================");

            currentInput = Console.ReadLine();
            if (int.TryParse(currentInput, out int number))
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

        private string GetUserInputNumberCalc(bool showWarning = true)
        {
            string firstCalc = "1";
            string secCalc = "2";
            string thirdCalc = "3";

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

                GetUserInputNumberCalc();
            }

            return checkedInput;
        }

        private string GetUserInputCurrency(bool showWarning = true)
        {
            const string hryvnia = "UAH";
            const string dollar = "USD";
            const string euro = "EUR";

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
                numberConv = Convert.ToDouble(currentInput);

                checkedInput = currentInput;
            }
            else if (isLetter == false && currentInput.Contains("."))
            {
                if (currentInput.Contains("."))
                {
                    numberConv = Convert.ToDouble(currentInput, chekPoint);
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
                numberConv = Convert.ToDouble(currentInput);

                checkedInput = currentInput;
            }
            else if (isLetter == false && currentInput.Contains("."))
            {
                if (currentInput.Contains("."))
                {
                    numberConv = Convert.ToDouble(currentInput, chekPoint);
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
            string plus = "+";
            string substruction = "-";
            string division = "/";
            string multiplication = "*";
            string persent = "%";

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
            string exit = "Exit";
            string calculatorAgain = "Calculate again";
            string exitToMainMenu = "Return";

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
                Console.WriteLine("Значение некорректно, попробуйте снова");
                GetUserInputCommand();
            }

            return checkedInput;
        }
    }
}