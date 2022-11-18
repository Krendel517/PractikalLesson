﻿using System;
using System.Globalization;
using System.Linq;

namespace PractikalLesson_1
{
    public class InputController : ICommand
    {
        private string currentInput;
        private string checkedInput;
        public double numberConv;
        private string invalidValue = "invalid value";
        public delegate void OnBackToMainMenuEntered();
        public event OnBackToMainMenuEntered backToMainMenuEntered;


        NumberFormatInfo chekPoint = new NumberFormatInfo()
        {
            NumberDecimalSeparator = "."
        };

        BaseCalculatorView baseCalculatorView = new SimpleCalculatorView();

        public string GetUserInput(bool showWarning = true)
        {
            if (currentInput.Contains(""))
            {
                baseCalculatorView.WtireWarning();

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
                    GetUserInputEmpty();
                    break;
                case TypeOfUserInput.year:
                    GetUserInputYear();
                    break;
                case TypeOfUserInput.number:
                    GetUserInputNumberOfCalculator();
                    break;
                case TypeOfUserInput.currency:
                    GetUserInputCurrency();
                    break;
                case TypeOfUserInput.money:
                    GetUserInputCalculateNumb();
                    break;
                case TypeOfUserInput.simpleNumber:
                    GetUserInputCalculateNumb();
                    break;
                case TypeOfUserInput.mathematicalActions:
                    GetUserInputMathAction();
                    break;
                case TypeOfUserInput.ageDateFormat:
                    GetUserInputGetData();
                    break;
                case TypeOfUserInput.seconds:
                    GetUserInputSeconds();
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
                    GetUserInputGetData(false);
                    break;
                case TypeOfUserInput.number:
                    GetUserInputNumberOfCalculator(false);
                    break;
                case TypeOfUserInput.currency:
                    GetUserInputCurrency(false);
                    break;
                case TypeOfUserInput.money:
                    GetUserInputCalculateNumb(false);
                    break;
                case TypeOfUserInput.simpleNumber:
                    GetUserInputCalculateNumb(false);
                    break;
                case TypeOfUserInput.mathematicalActions:
                    GetUserInputMathAction(false);
                    break;
                case TypeOfUserInput.seconds:
                    GetUserInputSeconds(false);
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
                    GetUserInputNumberOfCalculator();
                    break;
                case TypeOfUserInput.currency:
                    GetUserInputCurrency();
                    break;
                case TypeOfUserInput.money:
                    GetUserInputCalculateNumb();
                    break;
                case TypeOfUserInput.simpleNumber:
                    GetUserInputCalculateNumb();
                    break;
                case TypeOfUserInput.mathematicalActions:
                    GetUserInputMathAction();
                    break;
                case TypeOfUserInput.seconds:
                    GetUserInputSeconds();
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
            ExitEntered();
            BackToMainMenuEntered();

            if (currentInput.Contains(""))
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WtireWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return currentInput;
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
                baseCalculatorView.Clear();
                baseCalculatorView.WtireWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputNumberOfCalculator(bool showWarning = true)
        {
            string[] calculatorNumber = { "1", "2", "3", "4" };

            foreach (string calculatorNumberChecked in calculatorNumber)
            {
                ExitEntered();
                BackToMainMenuEntered();

                if (currentInput == calculatorNumberChecked)
                {
                    checkedInput = currentInput;
                    break;
                }
                else if (showWarning == true)
                {
                    checkedInput = invalidValue;
                    baseCalculatorView.WtireWarning();
                }
                else
                {
                    checkedInput = invalidValue;
                }
            }

            return checkedInput;
        }

        private string GetUserInputCurrency(bool showWarning = true)
        {
            const string hryvnia = "UAH";
            const string dollar = "USD";
            const string euro = "EUR";

            ExitEntered();
            BackToMainMenuEntered();

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
                baseCalculatorView.WtireWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputCalculateNumb(bool showWarning = true)
        {
            bool isLetter = currentInput.Any(Char.IsLetter);
            bool isDot = currentInput.Contains(".");
            bool isComma = currentInput.Contains(",");
            ExitEntered();
            BackToMainMenuEntered();

            if (double.TryParse(currentInput, out double number_1))
            {
                numberConv = Convert.ToDouble(currentInput);

                checkedInput = currentInput;
            }
            else if (isComma && isDot)
            {
                if (showWarning == true)
                {
                    checkedInput = invalidValue;
                    baseCalculatorView.WtireWarning();
                }
                else
                {
                    checkedInput = invalidValue;
                }
            }
            else if (!isLetter && isDot)
            {
                int numberOfDots = currentInput.Count(x => x == '.');

                if (numberOfDots > 1 && showWarning == true)
                {
                    checkedInput = invalidValue;
                    baseCalculatorView.WtireWarning();
                }
                else if (numberOfDots > 1)
                {
                    checkedInput = invalidValue;
                }
                else
                {
                    numberConv = Convert.ToDouble(currentInput, chekPoint);
                    checkedInput = currentInput;
                }
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WtireWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputMathAction(bool showWarning = true)
        {
            string[] allAction = { "+", "-", "/", "*", "%" };
            ExitEntered();
            BackToMainMenuEntered();

            foreach (var action in allAction)
            {
                if (currentInput == action)
                {
                    checkedInput = currentInput;
                    return checkedInput;
                }
                else if (showWarning == true)
                {
                    checkedInput = invalidValue;
                    baseCalculatorView.WtireWarning();
                }
                else
                {
                    checkedInput = invalidValue;
                }
            }

            return checkedInput;
        }

        private string GetUserInputGetData(bool showWarning = true)
        {
            bool isDate = DateTime.TryParse(currentInput, out DateTime result);
            if (isDate)
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WtireWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        private string GetUserInputSeconds(bool showWarning = true)
        {
            bool isLetter = currentInput.Any(Char.IsLetter);

            ExitEntered();
            BackToMainMenuEntered();

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
            else if (currentInput == "")
            {
                checkedInput = currentInput;
            }
            else if (showWarning == true)
            {
                checkedInput = invalidValue;
                baseCalculatorView.WtireWarning();
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
                baseCalculatorView.WtireWarning();
            }
            else
            {
                checkedInput = invalidValue;
            }

            return checkedInput;
        }

        public void ExitEntered()
        {
            if (currentInput == GlobalVariable.exit)
            {
                BaseCalculator baseCalculator = new SimpleCalculator("протсой калькулятор", 1);
                baseCalculator.ExitToProgram();
            }
        }

        public void BackToMainMenuEntered()
        {
            if (currentInput == GlobalVariable.exitToMainMenu)
            {
                backToMainMenuEntered?.Invoke();
            }
        }
    }
}