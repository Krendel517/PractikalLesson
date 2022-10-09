using PractikalLesson_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    abstract public class BaseCalculator
    {
        protected string Name { get; }
        protected int Id { get; }
        protected BaseCalculator(string name,int id)
        {
            Name = name;
            Id = id;
        }

        protected void Show()
        {
            Console.Clear();

            Console.WriteLine($"Вы выбрали {Name}");
            Console.WriteLine("Введите любую клавишу, чтобы продолжить.");

            Console.ReadKey();
            Console.Clear();
        }

        protected void ShowCommand()
        {
            const string calculatorAgain = "Calculate again";
            const string exitToMainMenu = "Return";
            const string exit = "Exit";

            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите {calculatorAgain}, чтобы посчитать заново.");
            Console.WriteLine($"Введите {exitToMainMenu} чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите {exit}");
            Console.WriteLine("======================================================");
        }

        protected void ExitToMainMenu()
        {
            MainMenu mainMenu = new MainMenu();

            Console.Clear();
            mainMenu.CalculatorSelection();
        }
    }
}



