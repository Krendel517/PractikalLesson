using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свой год рождения:");
            Console.Write("Вы работаутстроены?");
            Console.WriteLine(" ");
            Console.WriteLine("(Введите Yes если да и No если нет):");

            bool TripleWork, IsEighteen;
            int ReturnUser = Convert.ToInt32(Console.ReadLine());
            int adult = 2004;
            IsEighteen = ReturnUser <= adult;

            string input = Console.ReadLine();
            string TrueTripleWork = "Yes";
            TripleWork = input == TrueTripleWork;

            string Exite = "Exit";
            string UserInput = Console.ReadLine();
            if (IsEighteen & TripleWork)
            {
                CalculatorTax();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("На данный момент у вас нету возможности воспользоваться данными услугами, пожалуйста, введи Exit, чтобы выйти");
                if (Exite == UserInput)
                {
                    Console.ReadKey();
                }
            }

            void CalculatorTax()
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
                double sumOfIncome;

                Console.Clear();
                Console.WriteLine("Введите валюту вашего дохода");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса
                Console.WriteLine(" ");
                Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
                Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
                Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса

                string currence = Console.ReadLine();

                Console.Clear();

                //Вычисление суммы в гривнах
                sumOfIncome = Convert.ToDouble(Console.ReadLine());
                switch (currence)
                {
                    case hryvnia:
                        Console.WriteLine("Пожалуйста, введите сумму вашего дохода");
                        sumInHruvnia = sumOfIncome * kursHruvnia;
                        break;

                    case dollar:
                        Console.WriteLine("Пожалуйста, введите сумму вашего дохода");
                        sumInHruvnia = sumOfIncome * kursDollar;
                        break;

                    case euro:
                        Console.WriteLine("Пожалуйста, введите сумму вашего дохода");
                        sumInHruvnia = sumOfIncome * kursEuro;
                        break;
                }
                Tax(" ");

            //Прибыль, за вычетом 
            void Tax(string Input)
                {
                    string InputFalse = "Неизвестная команда, проверьте ввод и попробуйте снова";
                    Console.Clear();
                    Console.WriteLine(Input);
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
                    Console.WriteLine(" ");
                    Console.WriteLine("Введите Calculate again, чтобы посчитать заново.");
                    Console.WriteLine("Если же вы желаете выйти, введите Exit");

                    string exit = "Exit";
                    string userInput = Console.ReadLine();
                    string calculatorAgain = "Calculate again";

                    if (calculatorAgain == userInput)
                    {
                        CalculatorTax();
                    }
                    else if (exit == userInput)
                    {
                        Console.ReadKey();
                    }
                    else
                    {
                        Tax(InputFalse);
                    }
                }
            }
        }
    }
}
