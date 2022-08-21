using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            string calculatorCont = "Yeas";
            string calculatorNotCont = "No";
            string calculatorAgain = "Calculate again";
            string wrongInput = "";
            string input = " ";

            Console.WriteLine("Добро пожаловать вас в CalculateIncome :D");
            Console.WriteLine("________________________________________________");
            Console.WriteLine("Нажмите на любую клавишу, чтобы приступить к выполнению программы");

            Console.ReadKey();
            Console.Clear();

            Start();

            void Start()
            {
                Console.WriteLine(@"Введите свой год рождения
_____________________________");

                input = GetUserInput(TypeOfUserInput.year);

                if (input != wrongInput)
                {
                    Console.Clear();
                    ChooseCurrency();
                }
            }

            void ChooseCurrency()
            {
                Console.WriteLine("Нажмите любую клавишу чтобы присупить к вычислению годового дохода.");

                Console.ReadKey();
                string ticket = "ticket";

                while (input == calculatorAgain || ticket == "ticket")
                {
                    ticket = "";

                    Console.Clear();
                    Console.WriteLine("Введите валюту вашего дохода");
                    Console.WriteLine("_________________________________________");//Декоративная часть интерфейса
                    Console.WriteLine(" ");
                    Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
                    Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
                    Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
                    Console.WriteLine("_________________________________________");//Декоративная часть интерфейса

                    string inputCur = GetUserInput(TypeOfUserInput.currence);

                    string[] moth = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                    string[] monthlySalary = new string[12];
                    int[] monthlySalaryInt = new int[12];

                    for (int count = 0; count <= 11; count++)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите ваш доход за " + moth[count]);
                        monthlySalary[count] = GetUserInput(TypeOfUserInput.money);
                        monthlySalaryInt[count] = Convert.ToInt32(monthlySalary[count]);
                    }

                    int annualIncome = 0;
                    foreach (int annualIncomeInt in monthlySalaryInt)
                    {
                        annualIncome += annualIncomeInt;
                    }

                    if (input != wrongInput)
                    {
                        switch (inputCur)
                        {
                            case hryvnia:
                                sumInHruvnia = annualIncome * kursHruvnia;
                                break;

                            case dollar:
                                sumInHruvnia = annualIncome * kursDollar;
                                break;

                            case euro:
                                sumInHruvnia = annualIncome * kursEuro;
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


                    bool notReaction = input != calculatorCont || input != calculatorNotCont || input != calculatorAgain || input != exit;

                    Console.Clear();
                    Console.WriteLine("Ваш годовой доход состовляет " + annualIncome);
                    Console.WriteLine("____________________________________________");
                    Console.WriteLine("Нажмите любую клавишу, чтобы посмотреть ваш доход в грн.");

                    Console.ReadKey();
                    CalculateTax("");
                }

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

                    }
                    else if (input == exit)
                    {
                        Console.WriteLine("Нажмите на любую клавишу чтобы выйти.");
                        Console.ReadKey();
                    }
                    else if (input != exit || input != calculatorAgain)
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
                        Console.Clear();
                        Console.WriteLine("Значение некорректно, попробуйте снова");
                        Console.WriteLine("___________________________________________");

                        ChooseCurrency();
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
                        Console.Clear();
                        Console.WriteLine("Значение некорректно, попробуйте снова");
                        Console.WriteLine("___________________________________________");

                        ChooseCurrency();
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
