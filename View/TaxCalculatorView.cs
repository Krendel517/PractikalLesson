using System;

namespace PractikalLesson_1
{
    public class TaxCalculatorView : BaseCalculatorView
    {
        public void RequestEnterCurrency()
        {
            Console.WriteLine("Введите валюту вашего дохода");
            MediumDivisionLine();
            Console.WriteLine("Введите UAH, чтобы выбрать курс в гривнах  ");
            Console.WriteLine("Введите USD, чтобы выбрать курс в долларах  ");
            Console.WriteLine("Введите EUR, чтобы выбрать курс в евро  ");
            MediumDivisionLine();
        }

        public void ShowResult(string formatMoney,double annualIncome, string valut, double sumInHruvnia,double singleTax, double singleSocialContribution, double taxDeduction)
        {
            Console.Clear();
            Console.Write("Ваш годовой доход состовляет:" + formatMoney, annualIncome);
            Console.WriteLine(valut);
            MediumDivisionLine();
            Console.Write("Сумма в гривнах " + formatMoney, sumInHruvnia);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого налога равна " + formatMoney, singleTax);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого социального взноса равна " + formatMoney, singleSocialContribution);
            Console.WriteLine(" грн.");
            Console.Write("Ваша прибыль, за вычетом налогов равна " + formatMoney, taxDeduction);
            Console.WriteLine(" грн.");
        }
    }
}
