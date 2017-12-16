using System;

namespace pomodoro.BL
{
    /// <summary>
    /// A countdown timer is an asynchronously running timer
    /// that counts from a given timespan down to 0.
    /// 
    /// It has several methods available that control the flow
    /// and some events you can hook into to react on 
    /// certain situations.
    /// </summary>
    public class CountdownTimer
    {
        private TimeSpan CountdownTime { get; }
        private DateTime StartedAt { get; set; }

        public TimeSpan RemainingTime => CountdownTime - (DateTime.Now - StartedAt);
        public bool IsRunning => RemainingTime.TotalSeconds > 0;

        public CountdownTimer(TimeSpan countdownTime)
        {
            CountdownTime = countdownTime;
        }

        public void Start()
        {
            StartedAt = DateTime.Now;
        }
        
        
    }
}