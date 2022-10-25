
using System;

namespace PractikalLesson_1
{
    class MainMenu
    {
        UserInput userInput = new UserInput();

        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";
        int adult = 2004;
        int questionableAge = 1920;
        private string exit = "Exit";
        private string input;

        public void Show()
        {
            Start();
            CalculatorSelection();
        }

        private void Start()
        {
            Console.WriteLine("Введите свой год рождения");
            Console.WriteLine("===============================");

            input = userInput.GetUserInput(TypeOfUserInput.year);

            int inputYear = Convert.ToInt32(input);
            bool comingOfAge = inputYear < adult && inputYear > questionableAge;

            if (comingOfAge)
            {
                Console.Clear();
                CalculatorSelection();
            }
            else if (!comingOfAge)
            {
                Console.WriteLine("На данный момент вы не можете воспользоваться данными услагами, введите люблую клавишу, чтобы выйти.");
                
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void CalculatorSelection()
        {
            Console.WriteLine("Чтобы выбрать нужный вам калькулятор, введите соответствующую цифру или Exit, чтобы выйти.");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("1. Простой калькулятор");
            Console.WriteLine("2. Калькулятор возраста");
            Console.WriteLine("3. Калькулятор налогов");

            input = userInput.GetUserInput(TypeOfUserInput.number,TypeOfUserInput.command);

            if (input == firstCalc)
            {
                SimpleCalculator simpleCalculator = new SimpleCalculator("простой калькулятор", 1);

                Console.Clear();
                simpleCalculator.Show();
            }
            else if (input == secCalc)
            {
                AgeCalculator ageCalculator = new AgeCalculator("калькулятор возраста", 2);

                Console.Clear();
                ageCalculator.Show();
            }
            else if (input == thirdCalc)
            {
                TaxCalculator taxCalculator = new TaxCalculator("калькулятор налогов", 3);

                Console.Clear();
                taxCalculator.Show();
            }
            else if (input == exit)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введена неверная команда, попробуйте снова.");
                CalculatorSelection();
            }
        }
    }
}
