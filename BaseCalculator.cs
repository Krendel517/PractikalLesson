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
        UserInput checkInput = new UserInput();

        protected string input;
       
        protected string Name { get; }
        protected int Id { get; }
        protected BaseCalculator(string name,int id)
        {
            Name = name;
            Id = id;
        }

        protected void Show()
        {
            Console.WriteLine($"Вы выбрали {Name}");
            Console.WriteLine("Введите любую клавишу Enter, чтобы продолжить.");
            Console.WriteLine("(В любой момент вы можете ввести Return, чтобы вернутся обратно.)");
            Console.WriteLine("=========================================");

            input = checkInput.GetUserInput(TypeOfUserInput.returnInMainMenu, TypeOfUserInput.empty);

            if (input == "Return")
            {
                ExitToMainMenu();
            }
            else if (input == "")
            {
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Введенное значение не верно, попробуйте снова");
                Console.WriteLine("=========================================");

                Show();
            }
        }

        protected abstract void Calculate();

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

        protected void CheckReturnInput()
        {
            if (input == "Return")
            {
                ExitToMainMenu();
            }
        }

        protected void ExitToMainMenu()
        {
            MainMenu mainMenu = new MainMenu();

            Console.Clear();
            mainMenu.CalculatorSelection();
        }
    }
}



