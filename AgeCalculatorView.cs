using System;

namespace PractikalLesson_1
{
    class AgeCalculatorView : BaseCalculatorView
    {
        public override void ShowResult()
        {
            AgeCalculator ageCalculator = new AgeCalculator("калькулятор возраста", 2);

            Console.Clear();
            Console.WriteLine($"Возраст человека, который родился {GlobalVariable.checkedInput} составляет " + Math.Truncate(ageCalculator.agePerson));
            ShowCommand();
        }
    }
}
