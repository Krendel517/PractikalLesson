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

        protected void Show(string name)
        {
            Console.Clear();

            Console.WriteLine($"Вы выбрали {name}");
            Console.WriteLine("Введите любую клавишу, чтобы продолжить.");

            Console.ReadKey();
            Console.Clear();
        }

        protected void ExitToMainMenu()
        {
            MainMenu mainMenu = new MainMenu();

            Console.Clear();
            mainMenu.CalculatorSelection();
        }
    }
}
