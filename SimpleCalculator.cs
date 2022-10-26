using System;

namespace PractikalLesson_1
{
    class SimpleCalculator : BaseCalculator
    {
        public double firstNumber;
        public double secondNumber;
        public string action;
        public double answer;
        private const string plus = "+";
        private const string distribuctions = "-";
        private const string division = ":";
        private const string multiplicatoins = "*";
        private const string percent = "%";
        const string formatAnswer = "{0:N}";

        public SimpleCalculator(string name, int id) : base(name, id)
        {
        }

        SimpleCalculatorView simpleCalculatorView = new SimpleCalculatorView ("простой калькулятор",1);

        public override void Show()
        {
            simpleCalculatorView.WelcomeMessegeView();
            WelcomeMessege();
            GetInput();
            Calculate();
            ShowResult();
        }

        public override void GetInput()
        {
            simpleCalculatorView.RequestEnterFirstNumber();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber, TypeOfUserInput.command);

            simpleCalculatorView.ExiFromProgramOrMainMenu();
            firstNumber = userInput.numberConv;

            simpleCalculatorView.RequestEnterAction();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.mathematicalActions, TypeOfUserInput.command);

            simpleCalculatorView.ExiFromProgramOrMainMenu();
            action = GlobalVariable.checkedInput;

            simpleCalculatorView.RequestEnterSecondnumber();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber, TypeOfUserInput.command);

            simpleCalculatorView.ExiFromProgramOrMainMenu();
            secondNumber = userInput.numberConv;
        }

        public override void Calculate()
        {
            switch (action)
            {
                case plus:
                    answer = firstNumber + secondNumber;
                    break;

                case distribuctions:
                    answer = firstNumber - secondNumber;
                    break;

                case division:
                    answer = firstNumber / secondNumber;
                    break;

                case multiplicatoins:
                    answer = firstNumber * secondNumber;
                    break;

                case percent:
                    answer = firstNumber / secondNumber * 100;
                    break;
            }
        }

        public override void ShowResult()
        {
            if (action == "%")
            {
                Console.Clear();
                Console.Write($"Процентное соотношение {firstNumber} от {secondNumber} составляет - ");
                Console.Write(formatAnswer, answer);
                Console.WriteLine("%");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Результат вычисления {firstNumber} {action} {secondNumber} = {answer}");
            }

            simpleCalculatorView.ShowCommand();
            GetCommand();
        }
    }
}
