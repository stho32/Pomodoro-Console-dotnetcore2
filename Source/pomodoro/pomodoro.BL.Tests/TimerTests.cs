using System;
using System.Threading;
using Xunit;

namespace pomodoro.BL.Tests
{
    public class TimerTests
    {
        [Fact]
        public void Starting_a_timer_and_letting_it_run_for_5_seconds_gives_back_24_55_as_remaining_time()
        {
            var pomodoroTimer = new CountdownTimer(new TimeSpan(0, 25, 0));

            pomodoroTimer.Start();
            Thread.Sleep(4500);

            var remainingTime = pomodoroTimer.RemainingTime;
            Assert.Equal("24:55", remainingTime.ToString("mm\\:ss"));
        }
    }


}