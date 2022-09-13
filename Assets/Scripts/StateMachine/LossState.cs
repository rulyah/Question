namespace StateMachine
{
    public class LossState : State
    {
        public LossState(GameController game) : base(game)
        {
        }

        public override void OnEnter()
        {
            _game.wrongAnswerWindow.Show();
            _game.wrongAnswerWindow.onButtonClick += OnButtonClick;
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
            _game.wrongAnswerWindow.Hide();
            _game.wrongAnswerWindow.onButtonClick -= OnButtonClick;
        }
    }
}