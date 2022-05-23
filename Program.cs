﻿using System;
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
            double minimumWage = 6500;

            string hryvnia = "UAH";
            string dollar = "USD";
            string euro = "EUR";

            double kursDollar = 29.2;
            double kursHruvnia = 1;
            double kursEuro = 30.7;

            double singleSocialContribution = minimumWage * 0.22;
            double sumInHruvnia = 0;

            Console.WriteLine("Введите валюту вашего дохода");
            Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");

            string currence = Console.ReadLine();

            //Вычисление суммы в гривнах

            if (currence == hryvnia)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста, введите сумму");
                double sumOfIncome = Convert.ToDouble(Console.ReadLine());
                sumInHruvnia = sumOfIncome * kursHruvnia;
            }
            else if (currence == dollar)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста, введите сумму вашего дохода в виде ранее выбранной валюты ");
                double sumOfIncome = Convert.ToDouble(Console.ReadLine());
                sumInHruvnia = sumOfIncome * kursDollar;
            }

            else if (currence == euro)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста, введите сумму вашего дохода в виде ранее выбранной валюты ");
                double sumOfIncome = Convert.ToDouble(Console.ReadLine());
                sumInHruvnia = sumOfIncome * kursEuro;            
            }
            else
            {
                Console.WriteLine("Введено неверное значение, попробуйте снова!");
            }

            //Прибыль, за вычетом налогов

            Console.Clear();
            Console.WriteLine("Вот ваш счет!");
            Console.WriteLine("Сумма в гривнах"+sumInHruvnia);
            double singleTax = sumInHruvnia * 0.05;
            Console.WriteLine("Сумма единого налога равна:"+ singleTax);
            Console.WriteLine("Сумма единого социального взноса равна:"+singleSocialContribution);
            double taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;
            Console.WriteLine("Ваша прибыль, за вычетом налогов равна: :" + taxDeduction);

            Console.ReadKey();
        }
      
    }
}
