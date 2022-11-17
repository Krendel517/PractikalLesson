using System;

namespace PractikalLesson_1
{
    class TimerView : BaseCalculatorView
    {
        public void RequestEnterTime()
        {
            Console.WriteLine("Введите время которые вы будете отсчитывать.");
            Console.WriteLine("(Во время отсчета вы можете переназначить время указав введя новое число)");
        }

        public void CountdownWarning()
        {
            Timer timer = new Timer("секундомер", 4);
            timer.showResult += ShowResult;

            Console.WriteLine($"Идет отсчет до {GlobalVariable.checkedInput}-ти секунд.");
            Console.WriteLine("(Во время отсчета вы можете ввести кол-во секунд, которое вы можете прибавить к текущему времени.)");
        }

        public void ShowResult(double inputTime)
        {
            Timer timer = new Timer("секундомер", 4);
            Console.Clear();
            Console.Beep();
            Console.WriteLine(inputTime + " секунд прошло, введите следующие комманды, чтобы продолжить или прервать выполнение программы.");

            timer.showResult -= ShowResult;
        }
    }
}
