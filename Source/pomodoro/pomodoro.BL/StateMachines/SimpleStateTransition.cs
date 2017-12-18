using System;

namespace pomodoro.BL.StateMachines
{
    public class SimpleStateTransition : StateTransitionBase
    {
        public Func<bool> ToPerform { get; }

        public SimpleStateTransition(State fromState, string identifier, State toState, int priority,
            Func<bool> toPerform) 
            : base(fromState, identifier, toState, priority)
        {
            ToPerform = toPerform;
        }

        public override bool PerformTransitionToPointOfPossibleCommit()
        {
            return ToPerform();
        }

        public override void Rollback()
        {
        }

        public override void Commit()
        {
        }
    }
}