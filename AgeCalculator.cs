using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCalculator
{
    class AgeCalculator
    {
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

        public void ShowAllCalculator()
        {
            CalculateAge();
            ShowAnswer();
        }

        public void CalculateAge()
        {
            Console.WriteLine("Укажите дату рождения в формате дд.мм.гггг");
            Console.WriteLine("===========================================");
  
            UserInput chekInput = new UserInput();
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

        public void ShowAnswer()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"Введите {calculatorAgain}, чтобы посчитать заново.");
            Console.WriteLine($"Введите {exitToMainMenu} чтобы вернуться в окно выбора калькулятора");
            Console.WriteLine($"Если же вы желаете выйти, введите {exit}");
            Console.WriteLine("======================================================");

            UserInput chekInput = new UserInput();
            input = chekInput.GetUserInput(TypeOfUserInput.command);

            if (input == calculatorAgain)
            {
                Console.Clear();
                ShowAllCalculator();
            }
            else if (input == exitToMainMenu)
            {
                MainMenu mainMenu = new MainMenu();

                Console.Clear();
                mainMenu.CalculatorSelection();
            }
            else if (input == exit)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Значение некорректно, попробуйте снова");

                ShowAnswer();
            }

            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

