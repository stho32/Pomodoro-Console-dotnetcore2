using System;
using System.Threading;
using pomodoro.BL;

namespace pomodoro
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pomodoro has been started at " + DateTime.Now.ToShortTimeString());
            
            var timer = new CountdownTimer(new TimeSpan(0, 25, 0));
            timer.Start();
            
            while (timer.IsRunning)
            {
                Console.WriteLine(timer.RemainingTime.ToString("mm\\:ss"));
                Thread.Sleep(1000);
            }
            Console.WriteLine("GONG!!!");
            
            Console.WriteLine("Pomodoro has been finished at " + DateTime.Now.ToShortTimeString());
            Console.WriteLine("Please write down what you have been working on and start another one.");
        }
    }
}