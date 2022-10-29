using System;

namespace PractikalLesson_1
{
    class AgeCalculator : BaseCalculator
    {
        private DateTime todayData = DateTime.Today;
        private DateTime birthDay;
        private const double daysInYear = 365.2425;
        public double agePerson;
        private double ageInDays;

        public AgeCalculator(string name, int id) : base(name, id)
        {
        }

        AgeCalculatorView ageCalculatorView = new AgeCalculatorView("калькулятор возраста", 2);

        public override void Show()
        {
            ageCalculatorView.WelcomeMessegeView();
            WelcomeMessege();
            GetInput();
            Calculate();
            ShowResult();
        }

        public override void GetInput()
        {
            Console.WriteLine("Введите дату рождения какого-либо человека, чтобы узнать кол-во лет.");

            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.command, TypeOfUserInput.ageDateFormat);
            CheckReturnInput();
        }

        public override void Calculate()
        {
            birthDay = Convert.ToDateTime(GlobalVariable.checkedInput);

            TimeSpan ageForYears = todayData - birthDay;
            ageInDays = ageForYears.TotalDays;
            agePerson = ageInDays / daysInYear;
        }

        public override void ShowResult()
        {

            Console.Clear();
            Console.WriteLine($"Возраст человека, который родился {GlobalVariable.checkedInput} составляет " + Math.Truncate(agePerson));
            ageCalculatorView.ShowCommand();
            GetCommand();
        }
    }
}

