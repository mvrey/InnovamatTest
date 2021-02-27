using innovamattest.componentviews;
using innovamattest.models;
using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innovamattest.controllers
{
    public class NumbersGameController
    {
        public List<int> answers { get; set; }
        public string statement { get; set; }

        private AnswersController roundController;
        private Transform answersContainer;
        private List<AnswerComponentView> answerComponentViews;

        private List<string> numbersToText = new List<string>() { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez" };


        public NumbersGameController(Transform answersContainer)
        {
            roundController = new AnswersController();
            answerComponentViews = new List<AnswerComponentView>();
            this.answersContainer = answersContainer;
        }

        public void GenerateRoundData()
        {
            answers = GenerateAnswers(NumbersGameDataModel.Get().innovamatTestConfig.numAnswers);
            
            int rightAnswer = answers[UnityEngine.Random.Range(0, answers.Count)];
            statement = GenerateNumberWord(rightAnswer);

            roundController.wrongGuesses = 0;
            roundController.rightAnswer = rightAnswer;
        }

        public string GenerateNumberWord(int number)
        {
            return numbersToText[number];
        }

        public List<int> GenerateAnswers(int amount)
        {
            answers = new List<int>();

            while (answers.Count < amount)
            {
                int answer = UnityEngine.Random.Range(0, numbersToText.Count);

                if (!answers.Contains(answer))
                    answers.Add(answer);
            }

            return answers;
        }

        public void StartNewRound()
        {
            GenerateRoundData();

            if (answerComponentViews.Count == 0)
            {
                SpawnAnswers(answers);
            }

            for (int i = 0; i < answerComponentViews.Count; i++)
            {
                answerComponentViews[i].answerNumber = answers[i];
                answerComponentViews[i].buttonText.text = answers[i].ToString();
            }

            roundController.answerComponentViews = answerComponentViews;

            Messenger.SendMessage(MessageEnum.SetStatementText, new ArrayList() { statement });
            Messenger.SendMessage(MessageEnum.ShowStatement);
        }

        private void SpawnAnswers(List<int> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                AnswerComponentView answerComponentView = GameObject.Instantiate(NumbersGameDataModel.Get().innovamatTestConfig.answerPrefab, answersContainer);
                answerComponentViews.Add(answerComponentView);
            }
        }
    }
}
