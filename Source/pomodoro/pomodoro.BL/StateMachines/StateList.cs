using System.Collections.Generic;
using System.Linq;

namespace pomodoro.BL.StateMachines
{
    public class StateList : List<State>
    {
        public State ByIdentifier(string initialState)
        {
            return (
                    from s in this
                    where s.Identifier == initialState
                    select s)
                .FirstOrDefault();
        }
    }
}