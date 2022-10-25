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

        public override void Show()
        {
            WelcomeMessege();
            GetInput();
            Calculate();
            ShowResult();
        }

        public override void GetInput()
        {
            Console.WriteLine("Введите первое число.");
            Console.WriteLine("======================");
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber, TypeOfUserInput.command);

            if (GlobalVariable.checkedInput == "Return")
            {
                Console.Clear();
                CheckReturnInput();
            }

            firstNumber = userInput.numberConv;

            Console.Clear();
            Console.WriteLine("Введите требуемую операцию ( (+) - сложение, (-) -  вычитание, (/) - деление, (*) - умножение,  (%)  - сколько процентов составляет первое число от второго).");
            Console.WriteLine("========================================================================================================================");
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.mathematicalActions, TypeOfUserInput.command);

            if (GlobalVariable.checkedInput == "Return")
            {
                Console.Clear();
                CheckReturnInput();
            }

            action = GlobalVariable.checkedInput;

            Console.Clear();
            Console.WriteLine("Выберете второе число.");
            Console.WriteLine("======================");
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber, TypeOfUserInput.command);

            if (GlobalVariable.checkedInput == "Return")
            {
                Console.Clear();
                CheckReturnInput();
            }

            secondNumber = userInput.numberConv;
            Calculate();
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

            ShowFinalScreen();
        }
    }
}
