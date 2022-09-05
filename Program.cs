using System;
using System.Globalization;
using System.Linq;

namespace PractikalLesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = " ";

            StartTheProgram();

            void StartTheProgram()
            {
                Console.WriteLine("Добро пожаловать вас в CalculateIncome :D");
                Console.WriteLine("________________________________________________");
                Console.WriteLine("Нажмите на любую клавишу, чтобы приступить к выполнению программы");

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine(@"Введите свой год рождения
_____________________________");

                input = GetUserInput(TypeOfUserInput.year);

                MainMenu mainMenu = new MainMenu();
                mainMenu.CalculatorSelection();
            }

            string GetUserInput(TypeOfUserInput type)
            {
                string currentInput = "";
                string userInput = Console.ReadLine();
                int userInputInt = 0;

                if (type == TypeOfUserInput.year)
                {
                    int adult = 2004;
                    int questionableAge = 1920;
                    if (userInput.All(Char.IsDigit))
                    {
                      userInputInt = Convert.ToInt32(userInput);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Значение не корректно, введите любую клавишу чтобы выйти.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                    if (userInputInt <= adult && userInputInt >= questionableAge)
                    {
                        currentInput = userInput;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Значение не корректно, введите любую клавишу чтобы выйти.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                return currentInput;
            }
        }
    }
}
