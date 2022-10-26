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
    }
}
