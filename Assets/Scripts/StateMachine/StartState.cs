using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StartState : State
    {
        private readonly List<QuestionsConfig> _questions;
        
        public StartState(GameController game, List<QuestionsConfig> list) : base(game)
        {
            _questions = list;
        }

        public override void OnEnter()
        {
            _game.startWindow.Show();
            _game.startWindow.onButtonClick += OnButtonClick;
            _questions?.Clear();
            LoadResources(_questions);
        }

        private void OnButtonClick()
        {
            _game.stateMachine.ChangeState(new PrepareQuestionState(_game, _game.questions));
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            _game.startWindow.onButtonClick -= OnButtonClick;
            _game.startWindow.Hide();
        }
        public void LoadResources(List<QuestionsConfig> list)
        {
            var resources = Resources.LoadAll<QuestionsConfig>("QuestionConfig");
            list.AddRange(resources);
        }
    }
}