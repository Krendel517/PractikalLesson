
using System;

namespace PractikalLesson_1
{
    interface IVisible
    {
        void WelcomeMessegeView();

        void ShowCommand();
    }

    interface ICommand
    {
        void ExiFromProgramOrMainMenu();
    }

    public abstract class BaseCalculatorView : IVisible, ICommand
    {
        protected string name;
        protected int id;

        string Name { get { return name; } }
        int Id { get { return id; } }

        public BaseCalculatorView(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public void WelcomeMessegeView()
        {
            Console.WriteLine($"Вы выбрали {name}");
            Console.WriteLine("Введите клавишу Enter, чтобы продолжить.");
            Console.WriteLine("(В любой момент вы можете ввести Return, чтобы вернутся обратно.)");
            Console.WriteLine("=========================================");
        }

        public void ShowCommand()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите Calculate again, чтобы посчитать заново.");
            Console.WriteLine($"Введите Return чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите Exit");
            Console.WriteLine("======================================================");
        }

        public void ExiFromProgramOrMainMenu()
        {
            MainMenu mainMenu = new MainMenu();

            if (GlobalVariable.checkedInput == GlobalVariable.exitToMainMenu)
            {
                Console.Clear();
                mainMenu.CalculatorSelection();
            }
            else if (GlobalVariable.checkedInput == GlobalVariable.exit)
            {
                Environment.Exit(0);
            }
        }
    }
}
