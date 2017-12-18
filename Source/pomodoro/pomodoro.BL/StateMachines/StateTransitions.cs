using System.Collections.Generic;
using System.Linq;

namespace pomodoro.BL.StateMachines
{
    public class StateTransitions : List<StateTransitionBase>
    {
        public StateTransitions()
        {
        }

        private StateTransitions(List<StateTransitionBase> stateTransitions)
        {
            AddRange(stateTransitions);
        }

        public StateTransitions AllTransitionsFromTo(State fromState, State toState)
        {
            return new StateTransitions((
                from t in this
                where t.FromState.Identifier == fromState.Identifier &&
                      t.ToState.Identifier == toState.Identifier
                orderby t.Priority
                select t
            ).ToList());
        }

        public void Rollback()
        {
            ForEach(transition => transition.Rollback());
        }

        public void Commit()
        {
            ForEach(transition => transition.Commit());
        }
    }
}