using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerComponentView : FadeableComponentView, IMessageSubscriber
{
    public int answerNumber;

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

        Func<bool> OnHideAnswersDelegate = OnHideAnswers;
        Messenger.AddListener(MessageEnum.HideAnswers, OnHideAnswersDelegate);
    }

    public void RemoveMessageListeners()
    {
        
    }

    private bool OnShowAnswers()
    {
        StartCoroutine("ShowAnswersCoroutine");
        return true;
    }

    private bool OnHideAnswers()
    {
        FadeOut(2.0f);
        return true;
    }

    private IEnumerator ShowAnswersCoroutine()
    {
        button.interactable = false;
        buttonText.color = Color.white;

        FadeIn(2.0f);

        yield return new WaitForSeconds(2.0f);

        button.interactable = true;
    }

    public void OnMouseClick()
    {
        Messenger.SendMessage(MessageEnum.CheckAnswer, new ArrayList() { this });
    }

    public override void FadeOut(float time)
    {
        button.interactable = false;

        base.FadeOut(time);
    }
}
