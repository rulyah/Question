namespace StateMachine
{
    public class CorrectAnswerState : State
    {

        
        public CorrectAnswerState(GameController game) : base(game)
        {
        }

        public override void OnEnter()
        {
            _game.questionScreen.PlayCorrect((() =>
            {
                _game.stateMachine.ChangeState(new PrepareQuestionState(_game, _game.questions));
            }));
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }
}