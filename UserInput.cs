using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class UserInput
    {
        private string currentInput;
        public string chekedInput;

        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";    

        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";
        private string valut;

        private string exit = "Exit";
        private string calculatorAgain = "Calculate again";



        public string GetUserInput(TypeOfUserInput type,bool showWarning = true)
        {
            currentInput = Console.ReadLine();

            if (type == TypeOfUserInput.year)
            {
                int adult = 2004;
                int questionableAge = 1920;
                int currentInputInt = 0;

                if (currentInput.All(Char.IsDigit))
                {
                    currentInputInt = Convert.ToInt32(currentInput);
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, введите любую клавишу чтобы выйти.");
                    Console.WriteLine("===============================================================");

                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (currentInputInt <= adult && currentInputInt >= questionableAge)
                {
                    chekedInput = currentInput;
                    Console.Clear();
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, введите любую клавишу чтобы выйти.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            if (type == TypeOfUserInput.number)
            {
                if (currentInput == firstCalc || currentInput == secCalc || currentInput == thirdCalc || currentInput == exit)
                {
                    chekedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, попробуйте снова.");
                    Console.WriteLine("=========================================");

                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            if (type == TypeOfUserInput.currency)
            {
                if (currentInput == hryvnia)
                {
                    valut = " грн.";
                    currentInput = hryvnia;
                }

                else if (currentInput == dollar)
                {
                    valut = " дол.";
                    currentInput = dollar;
                }

                else if (currentInput == euro)
                {
                    valut = " евро";
                    currentInput = euro;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение некорректно, попробуйте снова");
                    Console.WriteLine("___________________________________________");

                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            else if (type == TypeOfUserInput.money)
            {
                if (currentInput.All(Char.IsDigit))
                {
                    chekedInput = currentInput;
                }
                else if (currentInput.All(Char.IsDigit) && currentInput.Contains("."))
                {
                    chekedInput = currentInput;
                }
                else if (currentInput.All(Char.IsDigit) && currentInput.Contains(","))
                {
                    chekedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение некорректно, попробуйте снова");
                    Console.WriteLine("___________________________________________");

                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            else if (type == TypeOfUserInput.command)
            {
                if (currentInput == calculatorAgain)
                {
                    chekedInput = currentInput;
                }
                else if (currentInput == exit)
                {
                    chekedInput = currentInput;
                }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            }
            return currentInput;
        }
        public string GetUserInput()
        {
            currentInput = Console.ReadLine();

            if (currentInput.Contains(""))
            {
                Console.WriteLine("Значение не корректно, введите любую клавишу, чтобы выйти");

                Console.ReadKey();
                Environment.Exit(0);
            } 
            else
            {
                Console.WriteLine("Ввод успешен, но все же нажмите любую клавишу чтобы выйти :)");

                Console.ReadKey();
                Environment.Exit(0);
            }

            return currentInput;
        }
    }
}