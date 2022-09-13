namespace StateMachine
{
    public class WrongAnswerState : State

    {
        public WrongAnswerState(GameController game) : base(game)
        {
        }

        public override void OnEnter()
        {
            _game.questionScreen.PlayWrong(() =>
            {
                _game.stateMachine.ChangeState(new LossState(_game));
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