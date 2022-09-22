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

        public void Show()
        {
            Start();
            CalculatorSelection();
        }

        private void Start()
        {
            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.year);
            int inputYear = Convert.ToInt32(input);

            if (inputYear < adult && inputYear > questionableAge)
            {
                Console.Clear();
                CalculatorSelection();
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
            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInputTwoType(TypeOfUserInput.number, TypeOfUserInput.exit);

            if (input == firstCalc)
            {
                SimpleCalculator simpleCalc = new SimpleCalculator();
                Console.Clear();
                simpleCalc.Start();
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
