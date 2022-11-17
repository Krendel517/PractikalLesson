
using System;

namespace PractikalLesson_1
{
    public abstract class BaseCalculator : BaseCalculatorView, ICalculate
    {
        protected InputController userInput = new InputController();

        protected string name;
        protected int id;

        protected string Name { get { return name; } }
        protected int Id { get { return id; } }

        protected BaseCalculator(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public abstract void Start();

        public void WelcomeMessege()
        {
            userInput.backToMainMenuEntered += ExitToMainMenu;
            WelcomeMessegeView(name);
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.empty);

            if (GlobalVariable.checkedInput == "")
            {
                Clear();
            }
            else
            {
                Clear();
                WtireWarning();

                WelcomeMessege();
            }
        }

        public abstract void GetInput();

        public abstract void Calculate();

        public void GetCommand()
        {
            ShowCommand();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.command);

            if (GlobalVariable.checkedInput == GlobalVariable.calculatorAgain)
            {
                CalculateAgain();
            }
            else if (GlobalVariable.checkedInput == GlobalVariable.exitToMainMenu)
            {
                ExitToMainMenu();
            }
            else if (GlobalVariable.checkedInput == GlobalVariable.exit)
            {
                ExitToProgram();
            }
        }

        public void CalculateAgain()
        {
            Clear();
            Start();
        }

        public void ExitToMainMenu()
        {
            MainMenu mainMenu = new MainMenu();
            userInput.backToMainMenuEntered -= ExitToMainMenu;

            Clear();
            mainMenu.CalculatorSelection();
        }

        public void ExitToProgram()
        {
            Environment.Exit(0);
        }
    }
}



