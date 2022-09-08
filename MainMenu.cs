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
        private string exit = "Exit";
        private string input;

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
