using System;

namespace PractikalLesson_1
{
    class SimpleCalculatorView : BaseCalculatorView
    {
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

        public void ShowResult(string action, double firstNumber, double secondNumber, double answer)
        {
            if (action == "%")
            {
                Console.Clear();
                Console.Write($"Процентное соотношение {firstNumber} от {secondNumber} составляет - ");
                Console.Write("{0:N}", answer);
                Console.WriteLine("%");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Результат вычисления {firstNumber} {action} {secondNumber} = {answer}");
            }
        }
    }
}
