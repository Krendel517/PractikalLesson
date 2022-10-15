using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class AgeCalculator : BaseCalculator
    {
        public AgeCalculator(string name, int id) : base(name, id)
        {
        }

        protected override void Calculate()
        {
            birthDay = Convert.ToDateTime(input);

            TimeSpan ageForYears = todayData - birthDay;
            ageInDays = ageForYears.TotalDays;
            agePerson = ageInDays / daysInYear;
        }

        private DateTime todayData = DateTime.Today;
        private DateTime birthDay;
        private const double daysInYear = 365.2425;
        private double agePerson;
        private double ageInDays;
        private string calculatorAgain = "Calculate again";
        private string exit = "Exit";
        private string exitToMainMenu = "Return";

        public void Start()
        {
            Show();
            CalculateAge();
            InputCommand();
        }

        public void CalculateAge()
        {
            InputAgeOfByrhtDayView();
            input = chekInput.GetUserInput(TypeOfUserInput.command, TypeOfUserInput.ageDateFormat);
            CheckReturnInput();

            Calculate();

            Console.Clear();
            Console.WriteLine($"Возраст человека, который родился {input} составляет " + Math.Truncate(agePerson));
            Console.WriteLine("==================================================");
            Console.WriteLine("Введите любую клавишу чтобы продолжить.");

            Console.ReadKey();
            Console.Clear();
        }

        public void InputCommand()
        {
            ShowCommand();
            input = chekInput.GetUserInput(TypeOfUserInput.command);

            if (input == calculatorAgain)
            {
                Console.Clear();
                Start();
            }
            else if (input == exitToMainMenu)
            {
                Console.Clear();
                ExitToMainMenu();
            }
            else if (input == exit)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Значение некорректно, попробуйте снова");

                InputCommand();
            }

            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

