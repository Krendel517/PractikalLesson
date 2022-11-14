
using System;

namespace PractikalLesson_1
{
    public abstract class BaseCalculatorView : IVisible
    {
        public void WelcomeMessegeView(string name)
        {
            Console.WriteLine($"Вы выбрали {name}");
            Console.WriteLine("Введите клавишу Enter, чтобы продолжить.");
            Console.WriteLine("(В любой момент вы можете ввести Return, чтобы вернутся обратно.)");
            Console.WriteLine("=========================================");
        }

        public void WtireWarning()
        {
            Console.WriteLine("Введенное значение не верно, попробуйте снова");
            Console.WriteLine("=========================================");
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ShowCommand()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите Calculate again, чтобы посчитать заново.");
            Console.WriteLine($"Введите Return чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите Exit");
            Console.WriteLine("======================================================");
        }
    }
}

