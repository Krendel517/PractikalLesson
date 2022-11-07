using System;

namespace PractikalLesson_1
{
    class AgeCalculatorView : BaseCalculatorView
    {
        public void ShowResult(double agePerson, DateTime birthDay)
        {
            Console.Clear();
            Console.WriteLine($"Возраст человека, который родился {birthDay} составляет " + Math.Truncate(agePerson));
        }
    }
}
