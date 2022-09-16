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
        UserInput chekInput = new UserInput();

        private string firstNumberStr;
        private string secondNumberStr;
        private double firstNumber;
        private double secondNumber;
        private string action;
        private string input;
        private double answer;
        private const string formatAnswer = "{0:N}";

        private const string calculatorAgain = "Calculate again";
        private const string exitToMainMenu = "Return";
        private const string exit = "Exit";

        public void Start()
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
            Console.Clear();

            Console.WriteLine("Выберете первое число");
            Console.WriteLine("======================");
            firstNumberStr = chekInput.GetUserInputSimpleNumb();
            firstNumber = chekInput.NumberConv;

            Console.Clear();
            Console.WriteLine("Введите требуемую операцию ( (+) - сложение, (-) -  вычитание, (/) - деление, (*) - умножение,  (%)  - сколько процентов составляет первое число от второго):");
            Console.WriteLine("========================================================================================================================");
            action = chekInput.GetUserInputMathAction();

            Console.Clear();
            Console.WriteLine("Выберете второе число");
            Console.WriteLine("======================");
            secondNumberStr = chekInput.GetUserInputSimpleNumb(); ;
            secondNumber = chekInput.NumberConv;

            Console.Clear();
        }

        public void CalculateNumbers()
        {
            switch (action)
            {
                case "+":
                    answer = firstNumber + secondNumber;
                    break;

                case "-":
                    answer = firstNumber - secondNumber;
                    break;

                case "/":
                    answer = firstNumber / secondNumber;
                    break;

                case "*":
                    answer = firstNumber * secondNumber;
                    break;

                case "%":
                    answer = firstNumber / secondNumber * 100;
                    break;
            }
        }
        void ShowCommand()
        {
            if (action == "%")
            {
                Console.Write($"Процентное соотношение {firstNumberStr} от {secondNumberStr} составляет - ");
                Console.Write(formatAnswer, answer);
                Console.WriteLine("%");
            }
            else
            {
                Console.WriteLine($"Результать вычисления {firstNumberStr} + {secondNumberStr} = " + answer);
            }

            Console.WriteLine("========================================");
            Console.WriteLine("Введите любую клавишу,чтобы продолжить.");
            Console.ReadKey();
          
            input = chekInput.GetUserInputCommand();

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
