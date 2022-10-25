
using System;

namespace PractikalLesson_1
{
    public abstract class BaseCalculator : ICalculate
    {
        protected UserInput userInput = new UserInput();

        protected string checkedInput;
        protected string name;
        protected int id;

        const string calculatorAgain = "Calculate again";
        const string exitToMainMenu = "Return";
        const string exit = "Exit";

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

            checkedInput = userInput.GetUserInput(TypeOfUserInput.command, TypeOfUserInput.empty);

            if (checkedInput == "Return")
            {
                MainMenu mainMenu = new MainMenu();
                Console.Clear();
                mainMenu.CalculatorSelection();
            }
            else if (checkedInput == "")
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

        public  abstract void GetInput();

        public  abstract void Calculate();

        public abstract void ShowResult();

        public void ShowFinalScreen()
        {
            ShowCommand();

            checkedInput = userInput.GetUserInput(TypeOfUserInput.command);

            if (checkedInput == calculatorAgain)
            {
                Console.Clear();
                Show();
            }
            else if (checkedInput == exitToMainMenu)
            {
                ExitToMainMenu();
            }
            else if (checkedInput == exit)
            {
                Environment.Exit(0);
            }
        }


        protected void CheckReturnInput()
        {
            if (checkedInput == "Return")
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



