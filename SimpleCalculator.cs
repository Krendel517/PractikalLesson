using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyCalculator
{
    class SimpleCalculator
    {
        private string firstNumber;
        private string secondNumber;
        private double firstNumberConv;
        private double secondNumberConv;
        private string action;
        private double answer;
        private string input;

        private const string addition = "+";
        private const string subtraction = "-";
        private const string division = "/";
        private const string multiplication = "*";
        private const string percent = "%";
        private string formatAnswer = "{0:N}";

        private string calculatorAgain = "Calculate again";
        private string exitToMainMenu = "Return";
        private string exit = "Exit";




        public void Order()
        {
            ShowTheCalculator();
            InputNumbers();
            CalculateNumbers();
            ShowCommand();
        }


        private void ShowTheCalculator()
        {
            Console.Clear();
            Console.WriteLine("Вы выбрали простой калькулятор, нажмите любую клавишу, чтобы приступить к работе");
            Console.WriteLine("=================================================================================");

            Console.ReadKey();
        }

        public void InputNumbers()
        {
            UserInput chekInput = new UserInput();

            NumberFormatInfo chekPoint = new NumberFormatInfo()
            {
                NumberDecimalSeparator = "."
            };

            NumberFormatInfo chekComma = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ","
            };

            Console.Clear();
            Console.WriteLine("Выберете первое число");
            Console.WriteLine("======================");
            firstNumber = chekInput.GetUserInput(TypeOfUserInput.numberForCalculate);

            if (firstNumber.Contains("."))
            {
                firstNumberConv = Convert.ToDouble(firstNumber, chekPoint);
            }
            else if (firstNumber.Contains(","))
            {
                firstNumberConv = Convert.ToDouble(firstNumber, chekComma);
            }
            else
            {
                firstNumberConv = Convert.ToDouble(firstNumber);
            }

            Console.Clear();
            Console.WriteLine("Введите требуемую операцию ( (+) - сложение, (-) -  вычитание, (/) - деление, (*) - умножение,  (%)  - сколько процентов составляет первое число от второго):");
            Console.WriteLine("========================================================================================================================");
            action = chekInput.GetUserInput(TypeOfUserInput.mathematicalActions);

            Console.Clear();
            Console.WriteLine("Выберете второе число");
            Console.WriteLine("======================");
            secondNumber = chekInput.GetUserInput(TypeOfUserInput.numberForCalculate);

            if (secondNumber.Contains("."))
            {
                secondNumberConv = Convert.ToDouble(secondNumber, chekPoint);
            }
            else if (secondNumber.Contains(","))
            {
                secondNumberConv = Convert.ToDouble(secondNumber, chekComma);
            }
            else
            {
                secondNumberConv = Convert.ToDouble(secondNumber);
            }

            Console.Clear();
        }

        public void CalculateNumbers()
        {
            switch (action)
            {
                case addition:
                    answer = firstNumberConv + secondNumberConv;
                    Console.WriteLine($"Резльтать вычисления {firstNumberConv} + {secondNumberConv} = " + answer);
                    break;

                case subtraction:
                    answer = firstNumberConv - secondNumberConv;
                    Console.WriteLine($"Резльтать вычисления {firstNumberConv} - {secondNumberConv} = " + answer);
                    break;

                case division:
                    answer = firstNumberConv / secondNumberConv;
                    Console.WriteLine($"Резльтать вычисления {firstNumberConv} : {secondNumberConv} = " + answer);
                    break;

                case multiplication:
                    answer = firstNumberConv * secondNumberConv;
                    Console.WriteLine($"Резльтать вычисления {firstNumberConv} * {secondNumberConv} = " + answer);
                    break;

                case percent:
                    answer = firstNumberConv / secondNumberConv * 100;

                    Console.Clear();
                    Console.Write($"Процентное соотношение {firstNumberConv} от {secondNumberConv} составляет -");
                    Console.Write(formatAnswer, answer);
                    Console.WriteLine("%");
                    break;
            }
            Console.WriteLine("========================================");
            Console.WriteLine("Введите любую клавишу,чтобы продолжить.");

            Console.ReadKey();
            Console.Clear();
        }
        void ShowCommand()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("Введите Calculate again, чтобы посчитать заново.");
            Console.WriteLine("Введите Return чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine("Если же вы желаете выйти, введите Exit");
            Console.WriteLine("======================================================");

            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.command);

            if (input == calculatorAgain)
            {
                Order();
                Console.Clear();
                Console.WriteLine("Нажмите любую клавишу, чтобы приступить к работе");
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
                ShowCommand();
            }
        }
    }
}
