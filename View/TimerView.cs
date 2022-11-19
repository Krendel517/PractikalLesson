using System;

namespace PractikalLesson_1.View
{
    public class TimerView : BaseCalculatorView
    {
        public void RequestEnterTime()
        {
            Console.WriteLine("Введите время которые вы будете отсчитывать.");
            Console.WriteLine("(Во время отсчета вы можете переназначить время указав введя новое число)");
        }

        public void CountdownWarning()
        {
            Console.WriteLine($"Идет отсчет до {GlobalVariable.checkedInput} секунд.");
            Console.WriteLine("(Во время отсчета вы можете ввести кол-во секунд, которое вы можете прибавить к текущему времени.)");
        }

        public void ShowResult(double inputTime)
        {
            Console.Clear();
            Console.Beep();
            Console.WriteLine(inputTime + " секунд прошло, введите следующие комманды, чтобы продолжить или прервать выполнение программы.");
        }
    }
}
