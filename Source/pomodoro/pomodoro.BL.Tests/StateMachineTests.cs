using System;
using System.Collections.Generic;
using System.Linq;
using pomodoro.BL.StateMachines;
using Xunit;

namespace pomodoro.BL.Tests
{
    public class StateMachineTests
    {
        private static StateMachine TimerStateMachine()
        {
            var ready = new State("Ready");
            var running = new State("Running");
            var paused = new State("Paused");

            var possibleStates = new StateList { ready, running, paused };

            var possibleTransitions = new StateTransitions();

            possibleTransitions.Add(new SimpleStateTransition(ready, "Start", running, 1, () => true));

            return new StateMachine(possibleStates, ready, possibleTransitions);
        }

        [Fact]
        public void When_the_timer_is_not_running_and_not_paused_it_is_ready()
        {
            var timer = TimerStateMachine();

            Assert.Equal("Ready", timer.ActiveState.Identifier);
        }

        [Fact]
        public void When_the_timer_is_started_then_its_state_is_running()
        {
            var timer = TimerStateMachine();

            timer.TransitionTo(timer.PossibleStates.ByIdentifier("Running"));

            Assert.Equal("Running", timer.ActiveState.Identifier);
        }

        [Fact]
        public void When_no_transitionhandler_is_available_for_the_requested_transition_then_an_exception_is_thrown()
        {
            var timer = TimerStateMachine();

            var exception = Assert.Throws<Exception>(() =>
            {
                timer.TransitionTo(timer.PossibleStates.ByIdentifier("Paused"));
            });

            Assert.Equal("A transition from state Ready to state Paused is not available.", exception.Message);
        }
    }

}