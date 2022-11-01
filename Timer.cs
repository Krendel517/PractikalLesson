using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class Timer : BaseCalculator
    {
        double inputTime;
        double time;
        private string formatSeconds = "{0:N}";
        const double millisecond = 0.1f;
        public Timer(string name, int id) : base(name, id)
        {
        }
        public override void Start()
        {
            WelcomeMessege();
            GetInput();
            Calculate();
            ShowResult();
        }

        public override void GetInput()
        {
            Console.WriteLine("Введите время которые вы будете отсчитывать.");
            Console.WriteLine("(Во время отсчета вы можете переназначить время указав введя новое число)");
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.money);
            inputTime = Convert.ToDouble(GlobalVariable.checkedInput);
        }

        public async override void Calculate()
        {
            Console.WriteLine($"Идет отсчет до {inputTime}-ти секунд.");
            Console.WriteLine("(Во время отсчета вы можете переназначить время указав введя новое число)");
            for (time = 0; time < inputTime;)
            {
                time += millisecond;
                await Task.Delay(100);
                Console.WriteLine(formatSeconds, time);
            }
        }
        public void ShowResult()
        {
            if (Math.Round(time) == inputTime)
            {
                Console.Clear();
                Console.Beep();
                Console.WriteLine(inputTime + " секунд прошло, введите следующие комманды, чтобы продолжить или прервать выполнение программы.");
                Console.WriteLine("==================================================================================================");

                GetCommand();
            }
            else
            {
                ShowResult();
            }
        }
    }
}
