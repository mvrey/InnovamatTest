using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreComponentView : ComponentView, IMessageSubscriber
{
    public TextMeshProUGUI sucessText;
    public TextMeshProUGUI failText;

    private void Start()
    {
        AddMessageListeners();
    }

    public void AddMessageListeners()
    {
        Func<bool> OnAddScoreSuccessDelegate = OnAddScoreSuccess;
        Messenger.AddListener(MessageEnum.AddScoreSuccess, OnAddScoreSuccessDelegate);

        Func<bool> OnAddScoreFailDelegate = OnAddScoreFail;
        Messenger.AddListener(MessageEnum.AddScoreFail, OnAddScoreFailDelegate);
    }

    public void RemoveMessageListeners()
    {
        
    }

    private bool OnAddScoreSuccess()
    {
        return true;
    }

    private bool OnAddScoreFail()
    {
        return true;
    }
}
