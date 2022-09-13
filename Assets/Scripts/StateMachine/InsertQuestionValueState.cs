namespace StateMachine
{
    public class InsertQuestionValueState : State
    {
        public InsertQuestionValueState(GameController game) : base(game)
        {
        }

        public override void OnEnter()
        {
            _game.questionScreen.InsertQuestionValue(_game.currentQuestion);
            _game.stateMachine.ChangeState(new ExpectAnswerState(_game, _game.timer));
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }
}