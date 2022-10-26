using System;

namespace PractikalLesson_1
{
    class TaxCalculatorView : BaseCalculatorView
    {
        public TaxCalculatorView(string name, int id) : base (name, id)
        {          
        }

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
            Console.Write("Ваш годовой доход состовляет:" + taxCalculator.formatMoney, taxCalculator.annualIncome);
            Console.WriteLine(taxCalculator.valut);
            Console.WriteLine("============================================");
            Console.Write("Сумма в гривнах " + taxCalculator.formatMoney, taxCalculator.sumInHruvnia);
            Console.WriteLine(" грн.");
            taxCalculator.singleTax = taxCalculator.sumInHruvnia * 0.05;
            Console.Write("Сумма единого налога равна " + taxCalculator.formatMoney, taxCalculator.singleTax);
            Console.WriteLine(" грн.");
            Console.Write("Сумма единого социального взноса равна " + taxCalculator.formatMoney, taxCalculator.singleSocialContribution);
            Console.WriteLine(" грн.");
            taxCalculator.taxDeduction = taxCalculator.sumInHruvnia - taxCalculator.singleTax - taxCalculator.singleSocialContribution;
            Console.Write("Ваша прибыль, за вычетом налогов равна " + taxCalculator.formatMoney, taxCalculator.taxDeduction);
            Console.WriteLine(" грн.");

            ShowCommand();
        }
    }
}
