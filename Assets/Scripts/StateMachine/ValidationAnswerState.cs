namespace StateMachine
{
    public class ValidationAnswerState : State
    {
        private readonly int _buttonId;
        public ValidationAnswerState(GameController game, int buttonId) : base(game)
        {
            _buttonId = buttonId;
        }

        public override void OnEnter()
        {
            _game.questionScreen.PlayConfirm(() =>
            {
                if (_buttonId == _game.currentQuestion.correctButtonId)
                {
                    _game.questions.Remove(_game.currentQuestion);
                    _game.stateMachine.ChangeState(new CorrectAnswerState(_game));
                }
                else
                {
                    _game.stateMachine.ChangeState(new WrongAnswerState(_game));
                }
            });
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }
}