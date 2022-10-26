using System;

namespace PractikalLesson_1
{
    class AgeCalculatorView : BaseCalculatorView
    {
        public AgeCalculatorView(string name, int id) : base (name, id)
        {
        }

        public override void ShowResult()
        {
            AgeCalculator ageCalculator = new AgeCalculator("калькулятор возраста", 2);

            Console.Clear();
            Console.WriteLine($"Возраст человека, который родился {GlobalVariable.checkedInput} составляет " + Math.Truncate(ageCalculator.agePerson));
            ShowCommand();
        }
    }
}
