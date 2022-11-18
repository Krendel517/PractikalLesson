
using System;

namespace PractikalLesson_1
{
    public abstract class BaseCalculator : ICalculate
    {
        protected InputController userInput = new InputController();
        protected BaseCalculatorView baseCalculatorView = new SimpleCalculatorView();

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
            baseCalculatorView.WelcomeMessegeView(name);
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.empty);

            if (GlobalVariable.checkedInput == "")
            {
                baseCalculatorView.Clear();
            }
            else
            {
                baseCalculatorView.Clear();
                baseCalculatorView.WtireWarning();
                WelcomeMessege();
            }
        }

        public abstract void GetInput();

        public abstract void Calculate();

        public void GetCommand()
        {
            baseCalculatorView.ShowCommand();
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
            baseCalculatorView.Clear();
            Start();
        }

        public void ExitToMainMenu()
        {
            MainMenu mainMenu = new MainMenu();
            userInput.backToMainMenuEntered -= ExitToMainMenu;

            baseCalculatorView.Clear();
            mainMenu.CalculatorSelection();
        }

        public void ExitToProgram()
        {
            Environment.Exit(0);
        }
    }
}



