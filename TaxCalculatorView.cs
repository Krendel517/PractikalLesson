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

        public override void ShowResult()
        {
            TaxCalculator taxCalculator = new TaxCalculator("калькулятор налогов", 3);

            Console.Clear();
            Console.Write("Ваш годовой доход состовляет:" + taxCalculator.FormatMoney, taxCalculator.AnnualIncome);
            Console.WriteLine(taxCalculator.Valut);
            Console.WriteLine("============================================");
            Console.Write("Сумма в гривнах " + taxCalculator.FormatMoney, taxCalculator.SumInHruvnia);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого налога равна " + taxCalculator.FormatMoney, taxCalculator.SingleTax);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого социального взноса равна " + taxCalculator.FormatMoney, taxCalculator.SingleSocialContribution);
            Console.WriteLine(" грн.");
            Console.Write("Ваша прибыль, за вычетом налогов равна " + taxCalculator.FormatMoney, taxCalculator.TaxDeduction);
            Console.WriteLine(" грн.");
            ShowCommand();
        }
    }
}
