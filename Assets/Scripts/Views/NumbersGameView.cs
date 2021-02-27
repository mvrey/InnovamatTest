using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGameView : MonoBehaviour, IMessageSubscriber
{
    private NumbersGameController numbersGameController;

    private List<AnswerComponentView> answerComponentViews;
    
    public Transform answersContainer;


    void Awake()
    {
        AddMessageListeners();
    }


    private void Start()
    {
        answerComponentViews = new List<AnswerComponentView>();

        numbersGameController = new NumbersGameController();

        StartNewRound();
    }

    private void SpawnAnswers(List<int> answers)
    {
        for (int i = 0; i < answers.Count; i++)
        {
            AnswerComponentView answerComponentView = Instantiate(NumbersGameDataModel.Get().innovamatTestConfig.answerPrefab, answersContainer);
            answerComponentViews.Add(answerComponentView);
        }
    }

    private void StartNewRound()
    {
        numbersGameController.GenerateRoundData();
        List<int> answers = numbersGameController.GetAnswers();

        if (answerComponentViews.Count == 0)
        {
            SpawnAnswers(answers);
        }

        for (int i = 0; i < answerComponentViews.Count; i++)
        {
            answerComponentViews[i].answerNumber = answers[i];
            answerComponentViews[i].buttonText.text = answers[i].ToString();
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
            Invoke("StartNewRound", 3.0f);
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
