using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyCalculator
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

        public void TheMainMenu()
        {
            Start();
            CalculatorSelection();
        }

        void Start()
        {
            Console.WriteLine(@"Введите свой год рождения
_____________________________");

            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.year);
            int inputYear = Convert.ToInt32(input);

            if (inputYear < adult && inputYear > questionableAge)
            {
                Console.Clear();

                MainMenu mainMenu = new MainMenu();
                mainMenu.CalculatorSelection();
            }
            else
            {
                Console.WriteLine("На данный момент вы не можете воспользоваться данными услагами, введите люблую клавишу, чтобы выйти.");

                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void CalculatorSelection()
        {
            Console.WriteLine("Чтобы выбрать нужный вам калькулятор, введите соответствующую цифру, или введите Exit чтобы выйти.");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("1. Простой калькулятор");
            Console.WriteLine("2. Калькулятор возраста");
            Console.WriteLine("3. Калькулятор налогов");

            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.number, TypeOfUserInput.command);

            if (input == firstCalc)
            {
                SimpleCalculator simpleCalc = new SimpleCalculator();
                Console.Clear();
                simpleCalc.SimpleTheCalculator();
            }
            else if (input == secCalc)
            {
                AgeCalculator ageCalc = new AgeCalculator();
                Console.Clear();
                ageCalc.AgeTheCalculator();
            }
            else if (input == thirdCalc)
            {
                TaxCalculator taxCalc = new TaxCalculator();
                Console.Clear();
                taxCalc.TaxCalculate();
            }
            else if (input == exit)
            {
                Environment.Exit(0);
            }
        }
    }
}
