using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class MainMenu
    {
        TaxCalculator taxCalc = new TaxCalculator();
        SimpleCalculator simpleCalc = new SimpleCalculator();
        AgeCalculator ageCalc = new AgeCalculator();

        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";
        private string exit = "Exit";
        private string input;

        public void ChooseCalculate()
        {
            Console.WriteLine("Чтобы выбрать нужный вам калькулятор, введите соответствующую цифру, или введите exit чтобы выйти.");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("1. Простой калькулятор");
            Console.WriteLine("2. Калькулятор возраста");
            Console.WriteLine("3. Калькулятор налогов");

            input = Console.ReadLine();

            if (input == firstCalc)
            {
                ageCalc.AgeTheCalculatore();
            }
            else if (input == secCalc)
            {
                simpleCalc.SimpleTheCalculatore();
            }
            else if (input == thirdCalc)
            {
                taxCalc.CalculateTheTax();
            }
            else if (input == exit)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Значение не корректно, попроейте снова.");
                Console.WriteLine("=========================================");
                ChooseCalculate();
            }
        }
    }
}
