using System;

namespace PractikalLesson_1
{
    public class SimpleCalculator : BaseCalculator
    {
        public double firstNumber;
        public double secondNumber;
        public string action;
        public string formatMoney = "{0:N}";
        public double answer;
        private const string plus = "+";
        private const string distribuctions = "-";
        private const string division = ":";
        private const string multiplicatoins = "*";
        private const string percent = "%";

        public SimpleCalculator(string name, int id) : base(name, id)
        {
        }

        SimpleCalculatorView simpleCalculatorView = new SimpleCalculatorView();

        public override void Start()
        {
            simpleCalculatorView.WelcomeMessegeView(name);
            WelcomeMessege();
            GetInput();
            Calculate();
            simpleCalculatorView.ShowResult();
        }

        public override void GetInput()
        {
            simpleCalculatorView.RequestEnterFirstNumber();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber, TypeOfUserInput.command);

            firstNumber = userInput.numberConv;

            simpleCalculatorView.RequestEnterAction();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.mathematicalActions, TypeOfUserInput.command);

            action = GlobalVariable.checkedInput;

            simpleCalculatorView.RequestEnterSecondnumber();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber, TypeOfUserInput.command);

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
    }
}
