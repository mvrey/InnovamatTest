using innovamattest.componentviews;
using innovamattest.models;
using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innovamattest.controllers
{
    public class AnswersController: IMessageSubscriber
    {
        public int successes = 0;
        public int fails = 0;
        public int rightAnswer { get; set; }
        public List<AnswerComponentView> answerComponentViews;

        public int wrongGuesses = 0;


        public AnswersController()
        {
            AddMessageListeners();
        }

        public void AddMessageListeners()
        {
            Func<ArrayList, bool> OnCheckAnswerDelegate = OnCheckAnswer;
            Messenger.AddListener(MessageEnum.CheckAnswer, OnCheckAnswerDelegate);
        }

        public void RemoveMessageListeners()
        {

        }

        private bool OnCheckAnswer(ArrayList data)
        {
            AnswerComponentView answerComponentView = data[0] as AnswerComponentView;

            if (answerComponentView.answerNumber == rightAnswer)
            {
                answerComponentView.buttonText.color = Color.green;
                successes++;
                Messenger.SendMessage(MessageEnum.HideAnswers);
                Messenger.SendMessage(MessageEnum.SetScoreSuccess, new ArrayList() { successes });

                Messenger.SendMessage(MessageEnum.StartNewRoundInTime, new ArrayList() { 3.0f });
            }
            else
            {
                wrongGuesses++;
                fails++;
                Messenger.SendMessage(MessageEnum.SetScoreFail, new ArrayList() { fails });
                answerComponentView.buttonText.color = Color.red;
                answerComponentView.FadeOut(2.0f);

                if (wrongGuesses == NumbersGameDataModel.Get().innovamatTestConfig.numAnswers - 1)
                {
                    AnswerComponentView rightAnswerComponent = answerComponentViews.Find(x => x.answerNumber == rightAnswer);
                    rightAnswerComponent.buttonText.color = Color.green;

                    Messenger.SendMessage(MessageEnum.HideAnswers);
                    Messenger.SendMessage(MessageEnum.StartNewRoundInTime, new ArrayList() { 3.0f });
                }
            }

            return true;
        }
    }
}
