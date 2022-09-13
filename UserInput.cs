using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCalculator
{
    class UserInput
    {
        private string currentInput;
        private string checkedInput;

        private string firstCalc = "1";
        private string secCalc = "2";
        private string thirdCalc = "3";

        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";

        private string exit = "Exit";
        private string calculatorAgain = "Calculate again";
        private string exitToMainMenu = "Return";

        public string GetUserInput(TypeOfUserInput firstType, TypeOfUserInput secondType)
        {
            if (firstType == TypeOfUserInput.year || secondType == TypeOfUserInput.year)
            {
                Console.WriteLine("Введите свой год рождения");
                Console.WriteLine("===============================");

                currentInput = Console.ReadLine();

                if (currentInput.All(Char.IsDigit))
                {
                    checkedInput = currentInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, попробуйте ввести нужное значение снова.");
                    Console.WriteLine("===============================================================");

                    GetUserInput(TypeOfUserInput.year);
                }
            }
            if (firstType == TypeOfUserInput.number || secondType == TypeOfUserInput.number)
            {
                Console.WriteLine("Чтобы выбрать нужный вам калькулятор, введите соответствующую цифру, или введите Exit чтобы выйти.");
                Console.WriteLine("=====================================================================");
                Console.WriteLine("1. Простой калькулятор");
                Console.WriteLine("2. Калькулятор возраста");
                Console.WriteLine("3. Калькулятор налогов");

                currentInput = Console.ReadLine();

                if (currentInput == firstCalc || currentInput == secCalc || currentInput == thirdCalc)
                {
                    checkedInput = currentInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, попробуйте снова.");
                    Console.WriteLine("=========================================");

                    GetUserInput(TypeOfUserInput.number);
                }
            }
            if (firstType == TypeOfUserInput.currency || secondType == TypeOfUserInput.currency)
            {
                Console.WriteLine("Введите валюту вашего дохода");
                Console.WriteLine("==========================================");//Декоративная часть интерфейса
                Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
                Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
                Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
                Console.WriteLine("==========================================");//Декоративная часть интерфейса

                currentInput = Console.ReadLine();

                if (currentInput == hryvnia)
                {
                    checkedInput = currentInput;
                }

                else if (currentInput == dollar)
                {
                    checkedInput = currentInput;
                }

                else if (currentInput == euro)
                {
                    checkedInput = currentInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Значение некорректно, попробуйте снова");
                    Console.WriteLine("=======================================");

                    GetUserInput(TypeOfUserInput.currency);
                }
            }
            else if (firstType == TypeOfUserInput.money || secondType == TypeOfUserInput.money)
            {
                currentInput = Console.ReadLine();
                bool isLetter = currentInput.All(Char.IsLetter);

                if (double.TryParse(currentInput, out double number))
                {
                    checkedInput = currentInput;
                }
                else if (isLetter == false && currentInput.Contains("."))
                {
                    checkedInput = currentInput;
                }
                else
                {
                    Console.WriteLine("Значение некорректно, попробуйте снова");
                    Console.WriteLine("========================================");

                    GetUserInput(TypeOfUserInput.money);
                }
            }
            else if (firstType == TypeOfUserInput.command || secondType == TypeOfUserInput.command)
            {
                currentInput = Console.ReadLine();

                if (currentInput == calculatorAgain)
                {
                    checkedInput = currentInput;
                }
                else if (currentInput == exit)
                {
                    checkedInput = currentInput;
                }
                else if (currentInput == exitToMainMenu)
                {
                    checkedInput = currentInput;
                }
            }
            return checkedInput;
        }

        public string GetUserInput(TypeOfUserInput firstType, bool showWarning = true)
        {
            if (firstType == TypeOfUserInput.year)
            {
                Console.WriteLine("Введите свой год рождения");
                Console.WriteLine("===============================");

                currentInput = Console.ReadLine();

                if (currentInput.All(Char.IsDigit))
                {
                    checkedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, попробуйте ввести нужное значение снова.");
                    Console.WriteLine("===============================================================");

                    GetUserInput(TypeOfUserInput.year);
                }
            }


            if (firstType == TypeOfUserInput.number)
            {
                Console.WriteLine("Чтобы выбрать нужный вам калькулятор, введите соответствующую цифру, или введите Exit чтобы выйти.");
                Console.WriteLine("=====================================================================");
                Console.WriteLine("1. Простой калькулятор");
                Console.WriteLine("2. Калькулятор возраста");
                Console.WriteLine("3. Калькулятор налогов");

                currentInput = Console.ReadLine();

                if (currentInput == firstCalc || currentInput == secCalc || currentInput == thirdCalc)
                {
                    checkedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, попробуйте снова.");
                    Console.WriteLine("=========================================");

                    GetUserInput(TypeOfUserInput.number);
                }
            }
            if (firstType == TypeOfUserInput.currency)
            {
                Console.WriteLine("Введите валюту вашего дохода");
                Console.WriteLine("==========================================");//Декоративная часть интерфейса
                Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
                Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
                Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
                Console.WriteLine("==========================================");//Декоративная часть интерфейса

                currentInput = Console.ReadLine();

                if (currentInput == hryvnia)
                {
                    checkedInput = currentInput;
                }

                else if (currentInput == dollar)
                {
                    checkedInput = currentInput;
                }

                else if (currentInput == euro)
                {
                    checkedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.Clear();
                    Console.WriteLine("Значение некорректно, попробуйте снова");

                    GetUserInput(TypeOfUserInput.currency);
                }
            }
            else if (firstType == TypeOfUserInput.money)
            {
                currentInput = Console.ReadLine();
                bool isLetter = currentInput.All(Char.IsLetter);
                
                if (double.TryParse(currentInput, out double number))
                {
                    checkedInput = currentInput;
                }
                else if (isLetter == false && currentInput.Contains("."))
                {
                    checkedInput = currentInput;
                }
                else if (showWarning == true)
                {
                    Console.WriteLine("Значение некорректно, попробуйте снова");
                    Console.WriteLine("========================================");

                    GetUserInput(TypeOfUserInput.money);
                }
            }
            else if (firstType == TypeOfUserInput.command)
            {
                currentInput = Console.ReadLine();

                if (currentInput == calculatorAgain)
                {
                    checkedInput = currentInput;
                }
                else if (currentInput == exit)
                {
                    checkedInput = currentInput;
                }
                else if (currentInput == exitToMainMenu)
                {
                    checkedInput = currentInput;
                }
            }
            else if (firstType == TypeOfUserInput.ageDateFormat)
            {
                currentInput = Console.ReadLine();

                CultureInfo culture;
                DateTimeStyles styles;
                DateTime dateResult;

                culture = CultureInfo.CreateSpecificCulture("fr-FR");
                styles = DateTimeStyles.None;

                if (DateTime.TryParse(currentInput, culture, styles, out dateResult))
                {
                    DateTime birthDayInput = DateTime.Parse(currentInput);
                    checkedInput = currentInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Значение не корректно, введите дату в формате дд.мм.гггг");

                    GetUserInput(TypeOfUserInput.ageDateFormat);
                }
            }
            return checkedInput;
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