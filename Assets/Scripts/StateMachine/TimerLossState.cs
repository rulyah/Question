namespace StateMachine
{
    public class TimerLossState : State
    {
        public TimerLossState(GameController game) : base(game)
        {
        }

        public override void OnEnter()
        {
            _game.timerLossWindow.Show();
            _game.timerLossWindow.onButtonClick += OnButtonClick;
        }

        private void OnButtonClick()
        {
            _game.stateMachine.ChangeState(new StartState(_game, _game.questions));
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            _game.timerLossWindow.onButtonClick -= OnButtonClick;
            _game.timerLossWindow.Hide();
        }
    }
}