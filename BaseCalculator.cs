using PractikalLesson_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    public class BaseCalculator
    {
        protected int id;
        protected string name;

        protected void Show()
        {
            int id;
            string name "";
            Console.WriteLine($"Вы выбрали {name}");
            Console.WriteLine("Введите любую клавишу, чтобы продолжить.");

            Console.Clear();
            Console.ReadKey();
        }

        protected void CalculateAgain()
        {
            TaxCalculator taxCalculator = new TaxCalculator();

            taxCalculator.Start();
            Console.Clear();
            Console.WriteLine("Нажмите любую клавишу, чтобы приступить к работе");
        }

        protected void ExitToMainMenu()
        {
            MainMenu mainMenu = new MainMenu();

            Console.Clear();
            mainMenu.CalculatorSelection();
        }
    }
}
