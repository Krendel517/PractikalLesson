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
        string invalidValue = "invalid value";

        NumberFormatInfo chekPoint = new NumberFormatInfo()
        {
            NumberDecimalSeparator = "."
        };

        public string GetUserInput(bool showWarning = true)
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

        public string GetUserInput(TypeOfUserInput type, bool showWarning = true)
        {
            currentInput = Console.ReadLine();

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

            if (checkedInput == invalidValue)
            {
                GetUserInput(type);
            }

            return checkedInput;
        }

        public string GetUserInput(TypeOfUserInput firstType, TypeOfUserInput secondType, bool showWarning = true)
        {
            currentInput = Console.ReadLine();

            switch (firstType)
            {
                case TypeOfUserInput.year:
                    GetUserInputYear(false);
                    break;

                case TypeOfUserInput.number:
                    GetUserInputNumberCalc();
                    break;

                case TypeOfUserInput.currency:
                    GetUserInputCurrency(false);
                    break;

                case TypeOfUserInput.money:
                    GetUserInputMoney(false);
                    break;

                case TypeOfUserInput.simpleNumber:
                    GetUserInputSimpleNumb(false);
                    break;

                case TypeOfUserInput.mathematicalActions:
                    GetUserInputMathAction(false);
                    break;

                case TypeOfUserInput.command:
                    GetUserInputCommand(false);
                    break;
            }

            if (checkedInput == invalidValue)
            {
                GetUserInputTwoType(firstType, secondType);
            }

            return checkedInput;
        }

        private string GetUserInputTwoType(TypeOfUserInput firstType, TypeOfUserInput secondType)
        {
            switch (secondType)
            {
                case TypeOfUserInput.year:
                    GetUserInputYear(false);
                    break;

                case TypeOfUserInput.number:
                    GetUserInputNumberCalc(false);
                    break;

                case TypeOfUserInput.currency:
                    GetUserInputCurrency(false);
                    break;

                case TypeOfUserInput.money:
                    GetUserInputMoney(false);
                    break;

                case TypeOfUserInput.simpleNumber:
                    GetUserInputSimpleNumb(false);
                    break;

                case TypeOfUserInput.mathematicalActions:
                    GetUserInputMathAction(false);
                    break;

                case TypeOfUserInput.command:
                    GetUserInputCommand(false);
                    break;
            }

            if (checkedInput == invalidValue)
            {
                GetUserInput(firstType, secondType);
            }

            return checkedInput;
        }

        private string GetUserInputYear(bool showWarning = true)
        {

            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;

                Console.Clear();
                Console.WriteLine("Значение не корректно, попробуйте ввести нужное значение снова.");
                Console.WriteLine("===============================================================");
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputNumberCalc(bool showWarning = true)
        {
            string firstCalc = "1";
            string secCalc = "2";
            string thirdCalc = "3";

            if (currentInput == firstCalc || currentInput == secCalc || currentInput == thirdCalc)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;

                Console.WriteLine("Значение не корректно, попробуйте снова.");
                Console.WriteLine("=========================================");
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputCurrency(bool showWarning = true)
        {
            const string hryvnia = "UAH";
            const string dollar = "USD";
            const string euro = "EUR";

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
                checkedInput = invalidValue;

                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("==========================================");
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputMoney(bool showWarning = true)
        {
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
                checkedInput = invalidValue;

                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("========================================");
                GetUserInput(TypeOfUserInput.money);
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputSimpleNumb(bool showWarning = true)
        {
            bool isLetter = currentInput.All(Char.IsLetter);

            if (double.TryParse(currentInput, out double number))
            {
                numberConv = Convert.ToDouble(currentInput);

                checkedInput = currentInput;
            }
            else if (!isLetter && currentInput.Contains("."))
            {
                if (currentInput.Contains("."))
                {
                    numberConv = Convert.ToDouble(currentInput, chekPoint);
                }

                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;

                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("========================================");
                GetUserInput(TypeOfUserInput.simpleNumber);
            }
            else
            {
                checkedInput = invalidValue;
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
                checkedInput = invalidValue;

                Console.WriteLine("Значение не верно, попробуйте снова.");
                Console.WriteLine("========================================");
                GetUserInput(TypeOfUserInput.mathematicalActions);
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputCommand(bool showWarning = true)
        {
            string exit = "Exit";
            string calculatorAgain = "Calculate again";
            string exitToMainMenu = "Return";

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
                checkedInput = invalidValue;

                Console.WriteLine("Значение некорректно, попробуйте снова");
                Console.WriteLine("=======================================");
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }
    }
}