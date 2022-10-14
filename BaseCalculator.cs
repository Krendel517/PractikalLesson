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
        protected string _name;
        protected int _id;

        protected BaseCalculator(string name, int id)
        {
            _name = name;
            _id = id;
        }

        protected string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected void Show()
        {
            Console.Clear();

            Console.WriteLine($"Вы выбрали {_name}");
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



