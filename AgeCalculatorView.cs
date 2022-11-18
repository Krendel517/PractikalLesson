using System;

namespace PractikalLesson_1
{
    class AgeCalculatorView : BaseCalculatorView
    {
        public void ShowResult(double agePerson)
        {
            Console.Clear();
            Console.WriteLine($"Возраст человека, который родился {GlobalVariable.checkedInput} составляет " + Math.Truncate(agePerson));
            ShowCommand();
        }
    }
}
