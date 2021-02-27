using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGameView : MonoBehaviour, IMessageSubscriber
{
    private NumbersGameController numbersGameController;

    public Transform answersContainer;

    public InnovamatTestConfig InnovamatTestConfig;

    void Awake()
    {
        AddMessageListeners();
    }


    private void Start()
    {
        numbersGameController = new NumbersGameController();

        numbersGameController.Execute();

        List<int> answers = numbersGameController.GetAnswers();

        for (int i = 0; i < answers.Count; i++)
        {
            AnswerComponentView answerComponentView = Instantiate(InnovamatTestConfig.answerPrefab, answersContainer);
            answerComponentView.answerNumber = answers[i];
            answerComponentView.buttonText.text = answers[i].ToString();
        }

        Messenger.SendMessage(MessageEnum.SetStatementText, new ArrayList() { numbersGameController.GetStatement() });
        Messenger.SendMessage(MessageEnum.ShowStatement);
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

        if (answerComponentView.answerNumber == numbersGameController.GetRightAnswer())
        {
            answerComponentView.buttonText.color = Color.green;
            numbersGameController.successes++;
            Messenger.SendMessage(MessageEnum.HideAnswers);
            Messenger.SendMessage(MessageEnum.SetScoreSuccess, new ArrayList() { numbersGameController.successes });
        }
        else
        {
            answerComponentView.buttonText.color = Color.red;
            numbersGameController.fails++;
            answerComponentView.FadeOut(2.0f);
            Messenger.SendMessage(MessageEnum.SetScoreFail, new ArrayList() { numbersGameController.fails });
        }

        return true;
    }
}
