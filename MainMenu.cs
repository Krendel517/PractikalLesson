
using System;

namespace PractikalLesson_1
{
    public class MainMenu
    {
        Controller userInput = new Controller();

        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";
        private string fourthCalc = "4";
        int adult = 2004;
        int questionableAge = 1920;
       
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
            Console.WriteLine("Чтобы выбрать нужную вам функцию, введите соответствующую цифру или Exit, чтобы выйти.");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("1. Простой калькулятор");
            Console.WriteLine("2. Калькулятор возраста");
            Console.WriteLine("3. Калькулятор налогов");
            Console.WriteLine("4. Секундоиер");

            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.number,TypeOfUserInput.command);

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
            else if (GlobalVariable.checkedInput == fourthCalc)
            {
                Timer timer = new Timer("секундомер", 4);

                Console.Clear();
                timer.Start();
            }
            else if (GlobalVariable.checkedInput == GlobalVariable.exit)
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
