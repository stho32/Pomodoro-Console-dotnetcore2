# Requirements for the State Machine

To control the timers operations I want a state machine that is easily configurable and
extendable. And saveable. I know the complexity of a timer is low, but I have lots of state
machines and possible state machines at work, so maybe this will work out on the longer run.

  - [ ] There is a state machine.
  - [ ] State machines can have a set of states.
  - [ ] There are transition handlers that define what is to do to go from one state to another. 
  - [ ] There can be multiple transition handlers for one transition. 
  - [ ] The execution order between the transition handlers is defined by the priority.
  - [ ] Only when all transition handlers are satisfied (no exceptions are thrown & they say its ok) the state of the state machine changes to the new state.
  - [ ] State handlers have a commit and a rollback function. These are called in case the transition is completly ok or not.
  - [ ] When there is no transition defined to go from state a to state b then an exception is thrown.
  - [ ] The state of the state machine can be loaded and saved at any time. 
  - [ ] The state machine can be visually displayed.