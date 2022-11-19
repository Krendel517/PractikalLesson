using System;

namespace PractikalLesson_1
{
    class AgeCalculator : BaseCalculator
    {
        AgeCalculatorView ageCalculatorView = new AgeCalculatorView();

        private DateTime todayData = DateTime.Today;
        private DateTime birthDay;
        private const double daysInYear = 365.2425;
        public double agePerson;
        private double ageInDays;

        public AgeCalculator(string name, int id) : base(name, id)
        {
        }
        public override void Start()
        {
            WelcomeMessege();
            GetInput();
            Calculate();
            ageCalculatorView.ShowResult(agePerson, birthDay);
            GetCommand();
        }

        public override void GetInput()
        {
            Console.WriteLine("Введите дату рождения какого-либо человека, чтобы узнать кол-во лет.");
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.ageDateFormat);
        }

        public override void Calculate()
        {
            birthDay = Convert.ToDateTime(GlobalVariable.checkedInput);

            TimeSpan ageForYears = todayData - birthDay;
            ageInDays = ageForYears.TotalDays;
            agePerson = ageInDays / daysInYear;
        }
    }
}

