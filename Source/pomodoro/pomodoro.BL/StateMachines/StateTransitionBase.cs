namespace pomodoro.BL.StateMachines
{
    public abstract class StateTransitionBase
    {
        public State FromState { get; }
        public string Identifier { get; }
        public State ToState { get; }
        public int Priority { get; }

        protected StateTransitionBase(State fromState, string identifier, State toState, int priority)
        {
            FromState = fromState;
            Identifier = identifier;
            ToState = toState;
            Priority = priority;
        }

        /// <summary>
        /// Prepare everything
        /// </summary>
        /// <returns>false if an error occured</returns>
        public abstract bool PerformTransitionToPointOfPossibleCommit();

        /// <summary>
        /// Execution failed, roll back what you wanted to do...
        /// </summary>
        public abstract void Rollback();

        /// <summary>
        /// Execution was a success, now "save to the database" or something like that.
        /// </summary>
        public abstract void Commit();
    }
}