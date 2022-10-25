
using System;

namespace PractikalLesson_1
{
    public abstract class BaseCalculator : ICalculate
    {
        protected UserInput userInput = new UserInput();

        protected string name;
        protected int id;

        protected string Name { get { return name; } }
        protected int Id { get { return id; } }

        protected BaseCalculator(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public abstract void Show();

        public void WelcomeMessege()
        {
            Console.WriteLine($"Вы выбрали {name}");
            Console.WriteLine("Введите клавишу Enter, чтобы продолжить.");
            Console.WriteLine("(В любой момент вы можете ввести Return, чтобы вернутся обратно.)");
            Console.WriteLine("=========================================");

            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.command, TypeOfUserInput.empty);

            if (GlobalVariable.checkedInput == "Return")
            {
                MainMenu mainMenu = new MainMenu();
                Console.Clear();
                mainMenu.CalculatorSelection();
            }
            else if (GlobalVariable.checkedInput == "")
            {
                Console.Clear();
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Введенное значение не верно, попробуйте снова");
                Console.WriteLine("=========================================");

                WelcomeMessege();
            }
        }

        public abstract void GetInput();

        public abstract void Calculate();

        public abstract void ShowResult();

        public void ShowFinalScreen()
        {
            ShowCommand();

            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.command);

            if (GlobalVariable.checkedInput == GlobalVariable.calculatorAgain)
            {
                Console.Clear();
                Show();
            }
            else if (GlobalVariable.checkedInput == GlobalVariable.exitToMainMenu)
            {
                ExitToMainMenu();
            }
            else if (GlobalVariable.checkedInput == GlobalVariable.exit)
            {
                Environment.Exit(0);
            }
        }

        protected void CheckReturnInput()
        {
            if (GlobalVariable.checkedInput == "Return")
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

        protected void ShowCommand()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите Calculate again, чтобы посчитать заново.");
            Console.WriteLine($"Введите Return чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите Exit");
            Console.WriteLine("======================================================");
        }
    }
}



