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
        private string firstNumberStr;
        private string secondNumberStr;
        private double firstNumber;
        private double secondNumber;
        private string action;
        private double answer;
        private string input;

        private const string addition = "+";
        private const string subtraction = "-";
        private const string division = "/";
        private const string multiplication = "*";
        private const string percent = "%";
        private const string formatAnswer = "{0:N}";

        private const string calculatorAgain = "Calculate again";
        private const string exitToMainMenu = "Return";
        private const string exit = "Exit";

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

            Console.Clear();
            Console.WriteLine("Выберете первое число");
            Console.WriteLine("======================");
            firstNumberStr = chekInput.GetUserInput(TypeOfUserInput.numberForCalculate);
            firstNumber = chekInput.NumberConv;

            Console.Clear();
            Console.WriteLine("Введите требуемую операцию ( (+) - сложение, (-) -  вычитание, (/) - деление, (*) - умножение,  (%)  - сколько процентов составляет первое число от второго):");
            Console.WriteLine("========================================================================================================================");
            action = chekInput.GetUserInput(TypeOfUserInput.mathematicalActions);

            Console.Clear();
            Console.WriteLine("Выберете второе число");
            Console.WriteLine("======================");
            secondNumberStr = chekInput.GetUserInput(TypeOfUserInput.numberForCalculate);
            secondNumber = chekInput.NumberConv;

            Console.Clear();
        }

        public void CalculateNumbers()
        {
            switch (action)
            {
                case addition:
                    answer = firstNumber + secondNumber;
                    break;

                case subtraction:
                    answer = firstNumber - secondNumber;
                    break;

                case division:
                    answer = firstNumber / secondNumber;
                    break;

                case multiplication:
                    answer = firstNumber * secondNumber;
                    break;

                case percent:
                    answer = firstNumber / secondNumber * 100;
                    break;
            }
        }
        void ShowCommand()
        {
            if (action == percent)
            {
                Console.Write($"Процентное соотношение {firstNumberStr} от {secondNumberStr} составляет - ");
                Console.Write(formatAnswer, answer);
                Console.WriteLine("%");
            }
            else
            {
                Console.WriteLine($"Резльтать вычисления {firstNumberStr} + {secondNumberStr} = " + answer);
            }

            Console.WriteLine("========================================");
            Console.WriteLine("Введите любую клавишу,чтобы продолжить.");

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите {calculatorAgain}, чтобы посчитать заново.");
            Console.WriteLine($"Введите {exitToMainMenu} чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите {exit}");
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
