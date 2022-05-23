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
         
            Console.WriteLine("Введите валюту,которой собираетесь оплатить налоги");
            Console.WriteLine("Введите UAH,чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD,чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR,чтобы выбрать курс в эвро  ");

            double minimumWage = 6500;

            string hryvnia = "UAH";
            string dollar = "USD";
            string euro = "EUR";

            double kursDollar = 29.2;
            double kursHruvnia = 1;
            double kursEuro = 30.7;
           


            string currence = Console.ReadLine();


            if (currence == hryvnia)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста,введите сумму");
                string sumOfIncomeInHruvnia = Console.ReadLine();
                double sumOfIncomeInHruvniaf = Convert.ToDouble(sumOfIncomeInHruvnia);
                double sumInHruvnia = sumOfIncomeInHruvniaf * kursHruvnia;
                Console.Clear();
                Console.WriteLine("Вот ваш счет!");
                Console.WriteLine(sumInHruvnia);
                double singleTax = sumInHruvnia * 0.05;
                Console.Write("ЕН:");
                Console.Write(singleTax);
                double singleSocialContribution = minimumWage * 0.22;
                Console.WriteLine(" ");
                Console.Write("ЕСВ:");
                Console.Write(singleSocialContribution);
                double taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;
                Console.WriteLine(" ");
                Console.Write("Итог:");
                Console.Write(taxDeduction);
            }
            else if (currence == dollar)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста,введите сумму вашего дохода в виде ранее выбранной валюты ");
                string sumOfIncomeInDollar = Console.ReadLine();
                double sumOfIncomeInDollarf = Convert.ToDouble(sumOfIncomeInDollar);
                double sumInHruvnia = sumOfIncomeInDollarf * kursDollar;
                Console.Clear();
                Console.WriteLine("Ваш счет в гривнах!");
                Console.WriteLine(sumInHruvnia);
                double singleTax = sumInHruvnia * 0.05;
                Console.Write("ЕН:");
                Console.Write(singleTax);
                double singleSocialContribution = minimumWage * 0.22;
                Console.WriteLine(" ");
                Console.Write("ЕСВ:");
                Console.Write(singleSocialContribution);
                double taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;
                Console.WriteLine(" ");
                Console.Write("Итог:");
                Console.Write(taxDeduction);


            }

            else if (currence == euro)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста,введите сумму вашего дохода в виде ранее выбранной валюты ");
                string sumOfIncomeInEuro = Console.ReadLine();
                double sumOfIncomeInEurof = Convert.ToDouble(sumOfIncomeInEuro);
                double sumInHruvnia = sumOfIncomeInEurof * kursEuro;
                Console.Clear();
                Console.WriteLine("Ваш счет в гривнах!");
                Console.WriteLine(sumInHruvnia);
                double singleTax = sumInHruvnia * 0.05;
                Console.Write("ЕН:");
                Console.Write(singleTax);
                double singleSocialContribution = minimumWage * 0.22;
                Console.WriteLine(" ");
                Console.Write("ЕСВ:");
                Console.Write(singleSocialContribution);
                double taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;
                Console.WriteLine(" ");
                Console.Write("Итог:");
                Console.Write(taxDeduction);
            }
            else
            {
                Console.WriteLine("Введено неверное значение,попробуйте снова!");
            }


            Console.ReadKey();


        }
      
    }
}
