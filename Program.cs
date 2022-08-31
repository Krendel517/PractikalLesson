﻿using System;
using System.Globalization;
using System.Linq;

namespace PractikalLesson_1
{
    class Program
    {
        enum TypeOfUserInput { year, currency, money, command };
        static void Main(string[] args)
        {
            const string hryvnia = "UAH";
            const string dollar = "USD";
            const string euro = "EUR";
            string formatMoney = "{0:N}";
            string valut = "";

            double kursDollar = 29.2;
            double kursEuro = 30.7;

            double minimumWage = 6500;
            double singleSocialContribution = minimumWage * 0.22;
            double sumInHruvnia = 0;
            double singleTax;
            double taxDeduction;
            string exit = "Exit";
            string calculatorAgain = "Calculate again";
            string wrongInput = "";
            string input = " ";

            Console.WriteLine("Добро пожаловать вас в CalculateIncome :D");
            Console.WriteLine("________________________________________________");
            Console.WriteLine("Нажмите на любую клавишу, чтобы приступить к выполнению программы");

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(@"Введите свой год рождения
_____________________________");

            input = GetUserInput(TypeOfUserInput.year);

            void ChooseCurrency()
            {

                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Введите валюту вашего дохода");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса
                Console.WriteLine(" ");
                Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
                Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
                Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса

                string inputCur = GetUserInput(TypeOfUserInput.currency);

                string[] moth = { "январь:", "февраль:", "март:", "апрель:", "май:", "июнь:", "июль:", "август:", "сентябрь:", "октябрь:", "ноябрь:", "декабрь:" };
                string[] monthlySalary = new string[12];
                double[] monthlySalaryInt = new double[12];


                NumberFormatInfo chekPoint = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = "."
                };

                NumberFormatInfo chekComma = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ","
                };

                for (int count = 0; count <= 11; count++)
                {
                    Console.Clear();
                    Console.WriteLine("Введите ваш доход за " + moth[count]);
                    monthlySalary[count] = Console.ReadLine();

                    if (monthlySalary[count].Contains("."))
                    {
                        monthlySalaryInt[count] = Convert.ToDouble(monthlySalary[count], chekPoint);
                    }
                    else if (monthlySalary[count].Contains(","))
                    {
                        monthlySalaryInt[count] = Convert.ToDouble(monthlySalary[count], chekComma);
                    }
                    else
                    {
                        monthlySalaryInt[count] = Convert.ToDouble(monthlySalary[count]);
                    }
                }

                double annualIncome = 0;
                foreach (double annualIncomeInt in monthlySalaryInt)
                {
                    annualIncome += annualIncomeInt;
                }

                if (input != wrongInput)
                {
                    switch (inputCur)
                    {
                        case hryvnia:
                            sumInHruvnia += annualIncome;
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

                Console.Clear();
                Console.Write("Ваш годовой доход состовляет:" + formatMoney, annualIncome);
                Console.WriteLine(valut);
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

                Console.Write("Сумма в гривнах " + formatMoney, sumInHruvnia);
                Console.WriteLine(" грн.");
                singleTax = sumInHruvnia * 0.05;
                Console.Write("Сумма единого налога равна " + formatMoney, singleTax);
                Console.WriteLine(" грн.");
                Console.Write("Сумма единого социального взноса равна " + formatMoney, singleSocialContribution);
                Console.WriteLine(" грн.");
                taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;
                Console.Write("Ваша прибыль, за вычетом налогов равна " + formatMoney, taxDeduction);
                Console.WriteLine(" грн.");
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
                    Environment.Exit(0);
                }
                else
                {
                    CalculateTax(InputFalse);
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
                        Console.Clear();
                        ChooseCurrency();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Значение не корректно.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                else if (type == TypeOfUserInput.currency)
                {
                    if (userInput == hryvnia)
                    {
                        valut = " грн.";
                        currentInput = hryvnia;
                    }

                    else if (userInput == dollar)
                    {
                        valut = " дол.";
                        currentInput = dollar;
                    }

                    else if (userInput == euro)
                    {
                        valut = " евро";
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
                }
                return currentInput;
            }
        }
    }
}
