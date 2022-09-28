using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCalculator
{
    class SimpleCalculator
    {
        UserInput chekInput = new UserInput();

        private string firstNumberStr;
        private string secondNumberStr;
        private double firstNumber;
        private double secondNumber;
        private string action;
        private string input;
        private double answer;
        private const string plus = "+";
        private const string distribuctions = "-";
        private const string division = "/";
        private const string multiplicatoins = "*";
        private const string percent = "%";

        public void Start()
        {
            ShowTheCalculator();
            InputNumbers();
            CalculateNumbers();
            ShowResult();
        }

        private void ShowTheCalculator()
        {
            Console.Clear();
            Console.WriteLine("Вы выбрали простой калькулятор, нажмите любую клавишу, чтобы приступить к работе");
            Console.WriteLine("=================================================================================");

            Console.ReadKey();
            Console.Clear();
        }

        private void InputNumbers()
        {
            Console.WriteLine("Выберете первое число");
            Console.WriteLine("======================");
            firstNumberStr = chekInput.GetUserInput(TypeOfUserInput.simpleNumber);
            firstNumber = chekInput.numberConv;
           
            Console.Clear();
            Console.WriteLine("Введите требуемую операцию ( (+) - сложение, (-) -  вычитание, (/) - деление, (*) - умножение,  (%)  - сколько процентов составляет первое число от второго):");
            Console.WriteLine("========================================================================================================================");
            action = chekInput.GetUserInput(TypeOfUserInput.mathematicalActions);

            Console.Clear();
            Console.WriteLine("Выберете второе число");
            Console.WriteLine("======================");
            secondNumberStr = chekInput.GetUserInput(TypeOfUserInput.simpleNumber);
            secondNumber = chekInput.numberConv;
        }

        private void CalculateNumbers()
        {
            switch (action)
            {
                case plus:
                    answer = firstNumber + secondNumber;
                    break;

                case distribuctions:
                    answer = firstNumber - secondNumber;
                    break;

                case division:
                    answer = firstNumber / secondNumber;
                    break;

                case multiplicatoins:
                    answer = firstNumber * secondNumber;
                    break;

                case percent:
                    answer = firstNumber / secondNumber * 100;
                    break;
            }
        }
        private void ShowResult()
        {
            const string calculatorAgain = "Calculate again";
            const string exitToMainMenu = "Return";
            const string exit = "Exit";
            const string formatAnswer = "{0:N}";

            if (action == "%")
            {
                Console.Clear();
                Console.Write($"Процентное соотношение {firstNumberStr} от {secondNumberStr} составляет - ");
                Console.Write(formatAnswer, answer);
                Console.WriteLine("%");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Результат вычисления {firstNumberStr} {action} {secondNumberStr} = " + answer);
            }

            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите {calculatorAgain}, чтобы посчитать заново.");
            Console.WriteLine($"Введите {exitToMainMenu} чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите {exit}");
            Console.WriteLine("======================================================");

            input = chekInput.GetUserInput(TypeOfUserInput.command);

            if (input == calculatorAgain)
            {
                Start();
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
        }
    }
}
