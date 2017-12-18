using System;
using System.Text;

namespace pomodoro.BL.StateMachines
{

    public class StateMachine
    {
        public State ActiveState { get; private set; }
        public StateList PossibleStates { get; }
        public State InitialState { get; }
        public StateTransitions PossibleTransitions { get; }

        public StateMachine(
            StateList possibleStates,
            State initialState,
            StateTransitions possibleTransitions)
        {
            PossibleStates = possibleStates;
            InitialState = initialState;
            PossibleTransitions = possibleTransitions;
            ActiveState = InitialState;
        }

        public void TransitionTo(State toState)
        {
            var fromState = ActiveState;
            var transitionHandlers = PossibleTransitions.AllTransitionsFromTo(fromState, toState);

            if (transitionHandlers.Count == 0)
                throw new Exception("A transition from state " + fromState.Identifier + " to state " +
                                    toState.Identifier + " is not available.");

            var runnedHandlers = new StateTransitions();

            foreach (var transitionHandler in transitionHandlers)
            {
                var partialTransitionWorked = transitionHandler.PerformTransitionToPointOfPossibleCommit();

                runnedHandlers.Add(transitionHandler);

                /* When there is at least one handler that is not satisfied, then 
                 * we roll back all handlers and we do not set the new state. 
                 * */
                if (!partialTransitionWorked)
                {
                    runnedHandlers.Rollback();
                    return;
                }
                    
            }

            runnedHandlers.Commit();
            ActiveState = toState;
        }
    }
}
