
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class Timer : BaseCalculator
    {
        TimerView timerView = new TimerView();

        private double inputTime;
        private double time;
        private const double millisecond = 0.1f;

        public Timer(string name, int id) : base(name, id)
        {
        }

        public override void Start()
        {
            WelcomeMessege();
            GetInput();
            AddTime();
            Calculate();
            timerView.ShowResult(inputTime);
            GetCommand();
        }

        public override void GetInput()
        {
            timerView.RequestEnterTime();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.simpleNumber);
            inputTime = Convert.ToDouble(GlobalVariable.checkedInput);
        }

        public async void AddTime()
        {
            await Task.Run(() =>
            {
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
            timerView.CountdownWarning();
            for (time = 0; time < inputTime;)
            {
                time += millisecond;
                Thread.Sleep(100);
                // Console.WriteLine(formatSeconds, time);
            }
        }
    }
}
