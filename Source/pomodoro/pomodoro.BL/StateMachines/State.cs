namespace pomodoro.BL.StateMachines
{
    public class State
    {
        public string Identifier { get; }

        public State(string identifier)
        {
            Identifier = identifier;
        }
    }
}