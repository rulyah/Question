namespace StateMachine
{
    public class VictoryState : State
    {
        public VictoryState(GameController game) : base(game)
        {
        }

        public override void OnEnter()
        {
            _game.victoryWindow.Show();
            _game.victoryWindow.onButtonClick += VictoryWindowOnButtonClick;
        }

        private void VictoryWindowOnButtonClick()
        {
            _game.stateMachine.ChangeState(new StartState(_game, _game.questions));
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {          
            _game.victoryWindow.onButtonClick -= VictoryWindowOnButtonClick;
            _game.victoryWindow.Hide();
        }
    }
}