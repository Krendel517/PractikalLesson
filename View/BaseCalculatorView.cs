
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
            MediumDivisionLine();
        }

        public void WriteWarning()
        {
            Console.WriteLine("Введенное значение не верно, попробуйте снова");
            MediumDivisionLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string ShowString(string text)
        {
            return text;
        }

        public void SkipThreeString()
        {
            Console.WriteLine(@"

");
        }

        public void LongDivisionLine()
        {
            Console.WriteLine("========================================================================================================================");
        }

        public void MediumDivisionLine()
        {
            Console.WriteLine("======================================================");
        }

        public void LowDivisionLine()
        {
            Console.WriteLine("======================");
        }

        public void ShowCommand()
        {
            MediumDivisionLine();
            Console.WriteLine($"Введите Calculate again, чтобы посчитать заново.");
            Console.WriteLine($"Введите Return чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите Exit");
            MediumDivisionLine();
        }
    }
}

