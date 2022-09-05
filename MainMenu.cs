using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class MainMenu
    {
        enum TypeOfUserInput { number, year, currency, money, command };

        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";
        private string exit = "Exit";
        private string input;

        public void CalculatorSelection()
        {
            Console.WriteLine("Чтобы выбрать нужный вам калькулятор, введите соответствующую цифру, или введите exit чтобы выйти.");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("1. Простой калькулятор");
            Console.WriteLine("2. Калькулятор возраста");
            Console.WriteLine("3. Калькулятор налогов");

            input = GetUserInput(TypeOfUserInput.number);

            string GetUserInput(TypeOfUserInput type)
            {
                string currentInput = "";
                string userInput = Console.ReadLine();

                if (type == TypeOfUserInput.number)
                {
                    if (userInput == firstCalc)
                    {
                        SimpleCalculator simpleCalc = new SimpleCalculator();
                        simpleCalc.SimpleTheCalculator();
                    }
                    else if (userInput == secCalc)
                    {
                        AgeCalculator ageCalc = new AgeCalculator();
                        ageCalc.AgeTheCalculator();
                    }
                    else if (userInput == thirdCalc)
                    {
                        TaxCalculator taxCalc = new TaxCalculator();
                        taxCalc.Calculate();
                    }
                    else if (userInput == exit)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Значение не корректно, попроейте снова.");
                        Console.WriteLine("=========================================");
                        CalculatorSelection();
                    }
                }
                return currentInput;
            }
        }
    }
}
