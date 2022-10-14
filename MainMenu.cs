using PractikalLesson_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class MainMenu
    {
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

            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.year);

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

            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.number,TypeOfUserInput.command);

            if (input == firstCalc)
            {
                SimpleCalculator simpleCalculator = new SimpleCalculator("простой калькулятор", 1);

                Console.Clear();
                simpleCalculator.Start();
            }
            else if (input == secCalc)
            {
                AgeCalculator ageCalculator = new AgeCalculator("калькулятор возраста", 2);

                Console.Clear();
                ageCalculator.Start();
            }
            else if (input == thirdCalc)
            {
                TaxCalculator taxCalculator = new TaxCalculator("калькулятор налогов", 3);

                Console.Clear();
                taxCalculator.Start();
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
