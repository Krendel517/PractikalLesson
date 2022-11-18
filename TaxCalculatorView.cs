using System;

namespace PractikalLesson_1
{
    public class TaxCalculatorView : BaseCalculatorView
    {
        public void RequestEnterCurrency()
        {
            Console.WriteLine("Введите валюту вашего дохода");
            Console.WriteLine("==========================================");
            Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
            Console.WriteLine("==========================================");
        }

        public void ShowResult(string formatMoney, string valut, double annualIncome, double sumInHrubnia, double singleTax, double singleSocialContribution, double taxDeduction )
        {
            Console.Clear();
            Console.Write("Ваш годовой доход состовляет:" + formatMoney, annualIncome);
            Console.WriteLine(valut);
            Console.WriteLine("============================================");
            Console.Write("Сумма в гривнах " + formatMoney, sumInHrubnia);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого налога равна " + formatMoney, singleTax);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого социального взноса равна " + formatMoney, singleSocialContribution);
            Console.WriteLine(" грн.");
            Console.Write("Ваша прибыль, за вычетом налогов равна " + formatMoney, taxDeduction);
            Console.WriteLine(" грн.");
            ShowCommand();
        }
    }
}
