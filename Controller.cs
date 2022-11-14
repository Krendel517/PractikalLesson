﻿using System;
using System.Globalization;
using System.Linq;

namespace PractikalLesson_1
{
    public class Controller : ICommand
    {
        BaseCalculatorView baseCalculatorView = new SimpleCalculatorView();

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
            if (currentInput.Contains(""))
            {
                baseCalculatorView.WriteWarning();

                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Значение корректно :D");
            }

            return currentInput;
        }

        public string GetUserInput(TypeOfUserInput type, bool showWarning = true)
        {
            currentInput = Console.ReadLine();

            switch (type)
            {
                case TypeOfUserInput.empty:
                    GetUserInput();
                    break;

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

                case TypeOfUserInput.ageDateFormat:
                    GetUserInputGetData();
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
                case TypeOfUserInput.empty:
                    GetUserInputEmpty(false);
                    break;
                case TypeOfUserInput.year:
                    GetUserInputYear(false);
                    break;
                case TypeOfUserInput.ageDateFormat:
                    GetUserInputGetData();
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
                GetUserInputTwoType(firstType, secondType);
            }

            return checkedInput;
        }

        private string GetUserInputTwoType(TypeOfUserInput firstType, TypeOfUserInput secondType)
        {
            switch (secondType)
            {
                case TypeOfUserInput.empty:
                    GetUserInputEmpty();
                    break;
                case TypeOfUserInput.year:
                    GetUserInputYear();
                    break;
                case TypeOfUserInput.ageDateFormat:
                    GetUserInputGetData();
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
                GetUserInput(firstType, secondType);
            }

            return checkedInput;
        }

        public string GetUserInputEmpty(bool showWarning = true)
        {
            Exit();
            BackToMainMenu();

            if (currentInput.Contains(""))
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WriteWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return currentInput;
        }

        private string GetUserInputYear(bool showWarning = true)
        {
            Exit();
            BackToMainMenu();

            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.Clear();
                baseCalculatorView.WriteWarning();
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

            Exit();
            BackToMainMenu();

            if (currentInput == firstCalc || currentInput == secCalc || currentInput == thirdCalc)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WriteWarning();
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

            Exit();
            BackToMainMenu();

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
                baseCalculatorView.WriteWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputMoney(bool showWarning = true)
        {
            bool isLetter = currentInput.Any(Char.IsLetter);

            Exit();
            BackToMainMenu();

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
                baseCalculatorView.WriteWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputSimpleNumb(bool showWarning = true)
        {
            bool isLetter = currentInput.Any(Char.IsLetter);

            Exit();
            BackToMainMenu();

            if (double.TryParse(currentInput, out double number_1))
            {
                numberConv = Convert.ToDouble(currentInput);

                checkedInput = currentInput;
            }
            else if (!isLetter && currentInput.Contains("."))
            {
                numberConv = Convert.ToDouble(currentInput, chekPoint);

                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WriteWarning();
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

            Exit();
            BackToMainMenu();

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
                baseCalculatorView.WriteWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputGetData(bool showWarning = true)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;

            culture = CultureInfo.CreateSpecificCulture("fr-FR");
            styles = DateTimeStyles.None;

            Exit();
            BackToMainMenu();

            if (DateTime.TryParse(currentInput, culture, styles, out dateResult))
            {
                DateTime birthDayInput = DateTime.Parse(currentInput);
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WriteWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputCommand(bool showWarning = true)
        {
            if (currentInput == GlobalVariable.calculatorAgain)
            {
                checkedInput = currentInput;

            }
            else if (currentInput == GlobalVariable.exit)
            {
                checkedInput = currentInput;
            }
            else if (currentInput == GlobalVariable.exitToMainMenu)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WriteWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        public void Exit()
        {
            if (currentInput == GlobalVariable.exit)
            {
                BaseCalculator baseCalculator = new SimpleCalculator("протсой калькулятор", 1);
                baseCalculator.ExitToProgram();
            }
        }

        public void BackToMainMenu()
        {
            if (currentInput == GlobalVariable.exitToMainMenu)
            {
                BaseCalculator baseCalculator = new SimpleCalculator("протсой калькулятор", 1);
                baseCalculator.ExitToMainMenu();
            }
        }
    }
}