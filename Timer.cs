
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class Timer : BaseCalculator
    {
        private double inputTime;
        private double time;
        private string formatSeconds = "{0:N}";
        private const double millisecond = 0.1f;
        public Timer(string name, int id) : base(name, id)
        {
        }

        private CancellationTokenSource s_cts = new CancellationTokenSource();

        public override void Start()
        {
            WelcomeMessege();
            GetInput();
            AddTime();
            Calculate();
            ShowResult();
        }

        public override void GetInput()
        {
            Console.WriteLine("Введите время которые вы будете отсчитывать.");
            Console.WriteLine("(Во время отсчета вы можете переназначить время указав введя новое число)");
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber);
            inputTime = Convert.ToDouble(GlobalVariable.checkedInput);
        }

        public async void AddTime()
        {
            await Task.Run(() =>
            {
                s_cts.CancelAfter((int)inputTime);
                char firstNumbChar = Console.ReadKey().KeyChar;
                string firstNumbStr = Convert.ToString(firstNumbChar);

                if (time < inputTime)          
                {
                    GlobalVariable.checkedInput = "";
                    GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.second);
                    firstNumbStr += GlobalVariable.checkedInput;

                    inputTime += Convert.ToDouble(firstNumbStr);
                }
            });        
        }

        public override void Calculate()
        {

            Console.WriteLine($"Идет отсчет до {inputTime}-ти секунд.");
            Console.WriteLine("(Во время отсчета вы можете ввести кол-во секунд, которое вы можете прибавить к текущему времени.)");
            for (time = 0; time < inputTime;)
            {
                time += millisecond;
                Thread.Sleep(100);
                // Console.WriteLine(formatSeconds, time);
            }
        }

        public void ShowResult()
        {
            Console.Clear();
            Console.Beep();
            Console.WriteLine(inputTime + " секунд прошло, введите следующие комманды, чтобы продолжить или прервать выполнение программы.");
            Console.WriteLine("==================================================================================================");

            GetCommand();
        }
    }
}
