using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class PrepareQuestionState : State
    {
        private readonly List<QuestionsConfig> _questions;
        public PrepareQuestionState(GameController game, List<QuestionsConfig> list) : base(game)
        {
            _questions = list;
        }

        public override void OnEnter()
        {
            _game.GenerateRandomQuestion();
            if (_game.currentQuestion != null)
            {
                _game.stateMachine.ChangeState(new InsertQuestionValueState(_game));
            }
            else
            {
                _game.stateMachine.ChangeState(new VictoryState(_game));
            }
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }
        private QuestionsConfig GetRandomQuestion()
        {
            return _questions.Count == 0 ? null : _questions[Random.Range(0, _questions.Count)];
        }
    }
}