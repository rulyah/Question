namespace StateMachine
{
    public abstract class State
    {
        protected readonly GameController _game;

        protected State(GameController game)
        {
            _game = game;
        }
        
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}