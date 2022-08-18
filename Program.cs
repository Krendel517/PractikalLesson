using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class Program
    {
        enum TypeOfUserInput { year, currence, money, command };
        static void Main(string[] args)
        {
            const string hryvnia = "UAH";
            const string dollar = "USD";
            const string euro = "EUR";

            double kursDollar = 29.2;
            double kursHruvnia = 1;
            double kursEuro = 30.7;

            double minimumWage = 6500;
            double singleSocialContribution = minimumWage * 0.22;
            double sumInHruvnia = 0;
            double singleTax;
            double taxDeduction;
            string exit = "Exit";
            string calculatorAgain = "Calculate again";
            string wrongInput = "";

            Console.WriteLine(@"Введите свой год рождения
_____________________________");

            string input;
            input = GetUserInput(TypeOfUserInput.year);

            if (input != wrongInput)
            {
                Console.Clear();
                IncomeForAnual();
            }
           
            void IncomeForAnual()
            {
                string[] moth = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                string[] monthlySalary = new string[12];
                int[] monthlySalaryInt = new int[12];
                int annualIncome;

                for (int count = 0; count <= 11; count++)
                {
                    Console.Clear();
                    Console.WriteLine("Введите ваш доход за " + moth[count]);
                    monthlySalary[count] = GetUserInput(TypeOfUserInput.money);
                    monthlySalaryInt[count] = Convert.ToInt32(monthlySalary[count]);
                }
                annualIncome = monthlySalaryInt[0] + monthlySalaryInt[1] + monthlySalaryInt[2] + monthlySalaryInt[3] + monthlySalaryInt[4] + monthlySalaryInt[5] + monthlySalaryInt[6]
                + monthlySalaryInt[7] + monthlySalaryInt[8] + monthlySalaryInt[9] + monthlySalaryInt[10] + monthlySalaryInt[11];

                Console.Clear();
                Console.WriteLine("Ваш годовой доход состовляет " + annualIncome);
                Console.WriteLine("____________________________________________");
                Console.WriteLine("Нажмите на любую клавижу чтобы продолжить");

                Console.ReadKey();
                ChooseCurrency();
            }


            void ChooseCurrency()
            {
                Console.Clear();
                Console.WriteLine("Введите валюту вашего дохода");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса
                Console.WriteLine(" ");
                Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
                Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
                Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса

                string inputCur = GetUserInput(TypeOfUserInput.currence);

                Console.Clear();

                //Вычисление суммы в гривнах
                Console.WriteLine(@"Пожалуйста, введите сумму вашего дохода
_____________________________________");

                input = GetUserInput(TypeOfUserInput.money);
                int inputMonye = Convert.ToInt32(input);

                if (input != wrongInput)
                {
                    switch (inputCur)
                    {
                        case hryvnia:
                            sumInHruvnia = inputMonye * kursHruvnia;
                            break;

                        case dollar:
                            sumInHruvnia = inputMonye * kursDollar;
                            break;

                        case euro:
                            sumInHruvnia = inputMonye * kursEuro;
                            break;
                    }
                }
                else
                {

                    Console.Clear();
                    Console.WriteLine("Значение некорректно, пропробуйте снова");
                    ChooseCurrency();
                    GetUserInput(TypeOfUserInput.money);
                }

                CalculateTax("");
                //Прибыль, за вычетом 
                void CalculateTax(string hollowString)
                {
                    string InputFalse = @"Значение не корректно, попробуйте снова
___________________________________________";

                    Console.Clear();
                    Console.WriteLine("Вот ваш счет!");
                    Console.WriteLine("_________________________________________");
                    Console.WriteLine(" ");
                    Console.WriteLine("Сумма в гривнах " + sumInHruvnia + " грн.");
                    singleTax = sumInHruvnia * 0.05;
                    Console.WriteLine($"Сумма единого налога равна {singleTax} грн.");
                    Console.WriteLine($"Сумма единого социального взноса равна {singleSocialContribution} ");
                    taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;
                    Console.WriteLine($"Ваша прибыль, за вычетом налогов равна {taxDeduction} грн.");
                    Console.WriteLine("_________________________________________");
                    Console.WriteLine("");
                    Console.WriteLine(hollowString);
                    Console.WriteLine("Введите Calculate again, чтобы посчитать заново.");
                    Console.WriteLine("Если же вы желаете выйти, введите Exit");

                    input = GetUserInput(TypeOfUserInput.command);

                    if (input == calculatorAgain)
                    {
                        ChooseCurrency();
                    }
                    else if (input == exit)
                    {
                        Console.ReadKey();
                    }
                    else
                    {
                        CalculateTax(InputFalse);
                    }
                }
            }

            string GetUserInput(TypeOfUserInput type)
            {
                string currentInput = "";
                string userInput = Console.ReadLine();

                if (type == TypeOfUserInput.year)
                {
                    int adult = 2004;
                    int questionableAge = 1920;
                    int userInputInt = Convert.ToInt32(userInput);
                    if (userInputInt <= adult && userInputInt >= questionableAge)
                    {
                        currentInput = userInput;
                    }
                    else
                    {
                        Console.WriteLine("Значение некорректно, нажмите любую клавишу, чтобы выйти");
                        Console.ReadKey();
                    }
                }
                else if (type == TypeOfUserInput.currence)
                {
                    if (userInput == hryvnia)
                    {
                        currentInput = hryvnia;
                    }

                    else if (userInput == dollar)
                    {
                        currentInput = dollar;
                    }

                    else if (userInput == euro)
                    {
                        currentInput = euro;
                    }
                    else
                    {
                        Console.WriteLine("Значение некорректно, нажмите любую клавишу, чтобы выйти");
                        Console.ReadKey();
                    }
                }
                else if (type == TypeOfUserInput.money)
                {
                    bool isNumber = userInput.All(Char.IsDigit);
                    if (isNumber)
                    {
                        currentInput = userInput;
                    }
                    else
                    {
                        Console.WriteLine("Значение некорректно, нажмите любую клавишу, чтобы выйти");
                        Console.ReadKey();
                    }
                }
                else if (type == TypeOfUserInput.command)
                {
                    if (userInput == calculatorAgain)
                    {
                        currentInput = userInput;
                    }
                    else if (userInput == exit)

                    {
                        currentInput = userInput;
                    }
                    else
                    {
                        Console.WriteLine("Значение некорректно, нажмите любую клавишу, чтобы выйти");
                        Console.ReadKey();
                    }
                }
                return currentInput;
            }
        }
    }
}
