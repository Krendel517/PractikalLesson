using System;
using System.Globalization;
using System.Linq;

namespace PractikalLesson_1
{
    class Start
    {
        static void Main(string[] args)
        {
            string input;

            Preview();
            Start();

            void Preview()
            {
                Console.WriteLine("Добро пожаловать вас в CalculateIncome :D");
                Console.WriteLine("________________________________________________");
                Console.WriteLine("Нажмите на любую клавишу, чтобы приступить к выполнению программы");

                Console.ReadKey();
                Console.Clear();
            }

            void Start()
            {
                Console.WriteLine(@"Введите свой год рождения
_____________________________");

                UserInput chekInput = new UserInput();
                input = chekInput.GetUserInput(TypeOfUserInput.year,false);


                Console.Clear();
                MainMenu mainMenu = new MainMenu();
                mainMenu.CalculatorSelection();
            }
        }
    }
}
