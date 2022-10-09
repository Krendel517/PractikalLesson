using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class AgeCalculator : BaseCalculator
    {
        UserInput chekInput = new UserInput();
        public AgeCalculator(string name, int id) : base(name, id)
        {
        }

        private DateTime todayData = DateTime.Today;
        private DateTime birthDay;
        private string birthDayInput;
        private const double daysInYear = 365.2425;
        private double agePerson;
        private double ageInDays;
        private string input;
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
            Console.WriteLine("Укажите дату рождения в формате дд.мм.гггг");
            Console.WriteLine("===========================================");

            birthDayInput = chekInput.GetUserInput(TypeOfUserInput.ageDateFormat);
            birthDay = Convert.ToDateTime(birthDayInput);

            TimeSpan ageForYears = todayData - birthDay;
            ageInDays = ageForYears.TotalDays;
            agePerson = ageInDays / daysInYear;

            Console.Clear();
            Console.WriteLine($"Возраст человека, который родился {birthDayInput} составляет " + Math.Truncate(agePerson));
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

