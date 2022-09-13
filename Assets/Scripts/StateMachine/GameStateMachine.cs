namespace StateMachine
{
    public class GameStateMachine
    {
        private State _currentState;

        public GameStateMachine(GameController game)
        {
            ChangeState(new StartState(game, game.questions));
        }

        public void Update()
        {
            _currentState.OnUpdate();
        }

        public void ChangeState(State state)
        {
            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();
        }
    }
}