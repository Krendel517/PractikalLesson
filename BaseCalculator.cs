
using System;

namespace PractikalLesson_1
{
    public abstract class BaseCalculator : BaseCalculatorView, ICalculate
    {
        protected Controller userInput = new Controller();

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
            WelcomeMessegeView(name);
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.command, TypeOfUserInput.empty);

            if (GlobalVariable.checkedInput == "Return")
            {
                MainMenu mainMenu = new MainMenu();
                Console.Clear();
                mainMenu.CalculatorSelection();
            }
            else if (GlobalVariable.checkedInput == "")
            {
                Clear();
            }
            else
            {
                Clear();
                WtireWarning();

                Start();
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
            Clear();
            mainMenu.CalculatorSelection();
        }

        public void ExitToProgram()
        {
            Environment.Exit(0);
        }
    }
}



