
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class Timer : BaseCalculator
    {
        private double inputTime;
        private double time;
        private const double millisecond = 0.1f;
        public delegate void ShowView(double inputTime);
        public event ShowView showResult;

        public TimerView timerView = new TimerView();

        public Timer(string name, int id) : base(name, id)
        {
        }

        public override void Start()
        {
            WelcomeMessege();
            GetInput();
            AddTime();
            Calculate();
            GetCommand();
        }

        public override void GetInput()
        {
            timerView.RequestEnterTime();
            GlobalVariable.checkedInput = userInput.GetUserInput(TypeOfUserInput.second);
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
            }

            timerView.ShowResult(inputTime);
        }
    }
}
