using System;
using System.Globalization;

namespace PractikalLesson_1
{
    public class TaxCalculator : BaseCalculator
    {

        TaxCalculatorView taxCalculatorView = new TaxCalculatorView();

        public TaxCalculator(string name, int id) : base(name, id)
        {
        }

        private int count;
        private double singleSocialContribution = minimumWage * 0.22;
        private double sumInHruvnia = 0;
        private double[] monthlySalaryDouble = new double[12];
        private string formatMoney = "{0:N}";
        private string valut = "";
        private double singleTax;
        private double taxDeduction;
        private double annualIncome = 0;
        private const string hryvnia = "UAH";
        private const string dollar = "USD";
        private const string euro = "EUR";
        private string inputCur;
        private const double minimumWage = 6500;
        private const double kursDollar = 29.2;
        private const double kursEuro = 30.7;
        private string[] mothStr = { "январь:", "февраль:", "март:", "апрель:", "май:", "июнь:", "июль:", "август:", "сентябрь:", "октябрь:", "ноябрь:", "декабрь:" };

        public double SingleSocialContribution => singleSocialContribution;
        public string FormatMoney { get { return formatMoney; } }
        public string Valut { get { return valut; } }
        public double SingleTax { get { return singleTax; } }
        public double TaxDeduction { get { return taxDeduction; } }
        public double AnnualIncome => annualIncome;
        public double SumInHruvnia { get { return sumInHruvnia; } }

        public override void Start()
        {
            WelcomeMessege();
            ChooseCurreny();
            GetInput();
            Calculate();
            taxCalculatorView.ShowResult();
            GetCommand();
        }

        private void ChooseCurreny()
        {
            taxCalculatorView.RequestEnterCurrency();
            inputCur = userInput.GetUserInput(TypeOfUserInput.currency, TypeOfUserInput.command);

            GlobalVariable.checkedInput = inputCur;
            
            if (inputCur == hryvnia)
            {
                valut = " грн.";
            }
            else if (inputCur == dollar)
            {
                valut = " дол.";
            }
            else if (inputCur == euro)
            {
                valut = " евро.";
            }
        }

        public override void GetInput()
        {
            string[] monthlySalaryStr = new string[12];

            NumberFormatInfo chekPoint = new NumberFormatInfo()
            {
                NumberDecimalSeparator = "."
            };

            NumberFormatInfo chekComma = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ","
            };

            for (count = 0; count <= 11; count++)
            {
                Console.Clear();
                Console.WriteLine("Введите ваш доход за " + mothStr[count]);
                Console.WriteLine("======================================");

                monthlySalaryStr[count] = userInput.GetUserInput(TypeOfUserInput.money, TypeOfUserInput.command);

                GlobalVariable.checkedInput = monthlySalaryStr[count];
               
                if (monthlySalaryStr[count].Contains("."))
                {
                    monthlySalaryDouble[count] = Convert.ToDouble(monthlySalaryStr[count], chekPoint);
                }
                else if (monthlySalaryStr[count].Contains(","))
                {
                    monthlySalaryDouble[count] = Convert.ToDouble(monthlySalaryStr[count], chekComma);
                }
                else
                {
                    monthlySalaryDouble[count] = Convert.ToDouble(monthlySalaryStr[count]);
                }
            }
        }

        public override void Calculate()
        {
            foreach (double annualIncomeInt in monthlySalaryDouble)
            {
                annualIncome += annualIncomeInt;
            }

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

            singleTax = sumInHruvnia - singleTax - singleSocialContribution;
            taxDeduction = sumInHruvnia - singleTax - singleSocialContribution;

            taxCalculatorView.ShowResult();
        }
    }
}

