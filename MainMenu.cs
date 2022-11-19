
using PractikalLesson_1.Model;
using System;

namespace PractikalLesson_1
{
    public class MainMenu
    {
        InputController userInput = new InputController();

        private const string firstCalc = "1";
        private const string secCalc = "2";
        private const string thirdCalc = "3";
        private const string fouthCalc = "4";
        private int adult = 2004;
        private int questionableAge = 1920;

        public void Show()
        {
            Start();
            CalculatorSelection();
        }

        private void Start()
        {
            Console.WriteLine("Введите свой год рождения");
            Console.WriteLine("===============================");

            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.year);

            int inputYear = Convert.ToInt32(GlobalVariable.checkedInput);
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
            Console.WriteLine("4. Секундомер");

            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.number);

            if (GlobalVariable.checkedInput == firstCalc)
            {
                SimpleCalculator simpleCalculator = new SimpleCalculator("простой калькулятор", 1);

                Console.Clear();
                simpleCalculator.Start();
            }
            else if (GlobalVariable.checkedInput == secCalc)
            {
                AgeCalculator ageCalculator = new AgeCalculator("калькулятор возраста", 2);

                Console.Clear();
                ageCalculator.Start();
            }
            else if (GlobalVariable.checkedInput == thirdCalc)
            {
                TaxCalculator taxCalculator = new TaxCalculator("калькулятор налогов", 3);

                Console.Clear();
                taxCalculator.Start();
            }
            else if (GlobalVariable.checkedInput == fouthCalc)
            {
                TimerCalculator timer = new TimerCalculator("секундомер", 4);

                Console.Clear();
                timer.Start();
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
