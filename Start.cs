using System;
using System.Globalization;
using System.Linq;

namespace PractikalLesson_1
{
    class Start
    {
        static void Main(string[] args)
        {
            int adult = 2004;
            int questionableAge = 1920;

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
                input = chekInput.GetUserInput(TypeOfUserInput.year, TypeOfUserInput.command);
                int inputYear = Convert.ToInt32(input);

                if (inputYear < adult && inputYear > questionableAge)
                {
                    Console.Clear();

                    MainMenu mainMenu = new MainMenu();
                    mainMenu.CalculatorSelection();
                }
                else
                {
                    Console.WriteLine("На данный момент вы не можете воспользоваться данными услагами, введите люблую клавишу, чтобы выйти.");

                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}
