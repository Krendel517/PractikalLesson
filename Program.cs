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
            Console.WriteLine("Введите свой год рождения");
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

            int userAge = Convert.ToInt32(Console.ReadLine());
           
            string input = Console.ReadLine();
            string exitTrigger = "Exit";
            bool isEighteen;
            bool exceedingLimitAge;
            int adult = 2004, questionableAge = 1920;
            isEighteen = userAge <= adult;
            exceedingLimitAge = userAge >= questionableAge;

            Console.WriteLine("Введите свой год рождения");

            if (isEighteen & exceedingLimitAge)
            {
                Console.Clear();
                ChooseCurrency();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("На данный момент у вас нету возможности воспользоваться данными услугами, пожалуйста, введи Exit, чтобы выйти");
                if (exitTrigger == input)
                {
                    Console.ReadKey();
                }
            }

            void ChooseCurrency()
            {

                Console.WriteLine("Введите валюту вашего дохода");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса
                Console.WriteLine(" ");
                Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
                Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
                Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
                Console.WriteLine("_________________________________________");//Декоративная часть интерфейса

                input = Console.ReadLine();
                Console.Clear();

                //Вычисление суммы в гривнах
                Console.WriteLine("Пожалуйста, введите сумму вашего дохода");
                sumOfIncome = Convert.ToDouble(Console.ReadLine());
                switch (input)
                {
                    case hryvnia:
                        sumInHruvnia = sumOfIncome * kursHruvnia;
                        break;

                    case dollar:
                        sumInHruvnia = sumOfIncome * kursDollar;
                        break;

                    case euro:
                        sumInHruvnia = sumOfIncome * kursEuro;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Значение некорректно, попробуйте снова!");
                        ChooseCurrency();
                        break;
                }
                CalculateTax("");

            //Прибыль, за вычетом 
            void CalculateTax(string HollowString)
                {
                    string exit = "Exit";
                    input = Console.ReadLine();
                    string calculatorAgain = "Calculate again";
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
                    Console.WriteLine(" ");
                    Console.WriteLine(HollowString);
                    Console.WriteLine(" ");
                    Console.WriteLine("Введите Calculate again, чтобы посчитать заново.");
                    Console.WriteLine("Если же вы желаете выйти, введите Exit");

                    if (calculatorAgain == input)
                    {
                        Console.Clear();
                        ChooseCurrency();
                    }
                    else if (exit == input)
                    {
                        Console.ReadKey();
                    }
                    else
                    {
                        CalculateTax(InputFalse);
                    }
                }
            }
        }
    }
}
