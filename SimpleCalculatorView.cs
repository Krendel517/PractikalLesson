using System;

namespace PractikalLesson_1
{
    class SimpleCalculatorView : BaseCalculatorView
    {
        public SimpleCalculatorView(string name, int id) : base(name, id)
        {
        }

        public void RequestEnterFirstNumber()
        {
            Console.Clear();
            Console.WriteLine("Введите первое число.");
            Console.WriteLine("======================");
        }

        public void RequestEnterAction()
        {
            Console.Clear();
            Console.WriteLine("Введите требуемую операцию ( (+) - сложение, (-) -  вычитание, (/) - деление, (*) - умножение,  (%)  - сколько процентов составляет первое число от второго).");
            Console.WriteLine("========================================================================================================================");
        }

        public void RequestEnterSecondnumber()
        {
            Console.Clear();
            Console.WriteLine("Выберете второе число.");
            Console.WriteLine("======================");
        }

        public override void ShowResult()
        {
            SimpleCalculator simpleCalculator = new SimpleCalculator("простой калькулятор", 1);

            if (simpleCalculator.action == "%")
            {
                Console.Clear();
                Console.Write($"Процентное соотношение {simpleCalculator.firstNumber} от {simpleCalculator.secondNumber} составляет - ");
                Console.Write("{0:N}", simpleCalculator.answer);
                Console.WriteLine("%");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Результат вычисления {simpleCalculator.firstNumber} {simpleCalculator.action} {simpleCalculator.secondNumber} = {simpleCalculator.answer}");
            }

            ShowCommand();
        }
    }
}
