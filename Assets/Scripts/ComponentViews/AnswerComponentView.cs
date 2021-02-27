using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerComponentView : FadeableComponentView, IMessageSubscriber
{
    public Button button;
    public TextMeshProUGUI buttonText;


    private void Awake()
    {
        AddMessageListeners();
    }

    public void AddMessageListeners()
    {
        Func<bool> OnShowAnswersDelegate = OnShowAnswers;
        Messenger.AddListener(MessageEnum.ShowAnswers, OnShowAnswersDelegate);
    }

    public void RemoveMessageListeners()
    {
        
    }

    private bool OnShowAnswers()
    {
        StartCoroutine("ShowAnswersCoroutine");
        return true;
    }

    private IEnumerator ShowAnswersCoroutine()
    {
        button.interactable = false;

        FadeIn(2.0f);

        yield return new WaitForSeconds(2.0f);

        button.interactable = true;
    }
}
