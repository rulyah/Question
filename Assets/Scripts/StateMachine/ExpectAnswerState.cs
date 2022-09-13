using UI;

namespace StateMachine
{
    public class ExpectAnswerState : State
    {
        private readonly Timer _timer;
        public ExpectAnswerState(GameController game, Timer timer) : base(game)
        {
            _timer = timer;
        }

        public override void OnEnter()
        {
            _game.questionScreen.onAnswerClick += OnAnswerClick;
            _timer.isTimerGo = true;
        }

        private void OnAnswerClick(int buttonId)
        {
            _game.stateMachine.ChangeState(new ValidationAnswerState(_game, buttonId));
        }
        public override void OnUpdate()
        {
            _timer.TickTimer();
            if (_timer.time <= 0)
            {
                _game.stateMachine.ChangeState(new TimerLossState(_game));
            }
        }

        public override void OnExit()
        {
            _game.questionScreen.onAnswerClick -= OnAnswerClick;
            _timer.isTimerGo = false;
            _timer.Refresh();
        }
    }
}