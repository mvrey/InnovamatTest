using innovamattest.componentviews;
using innovamattest.controllers;
using innovamattest.models;
using mvreylib.features.messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innovamattest.views
{
    public class NumbersGameView : MonoBehaviour, IMessageSubscriber
    {
        private NumbersGameController numbersGameController;

        public Transform answersContainer;


        private void Awake()
        {
            AddMessageListeners();
        }

        private void Start()
        {
            numbersGameController = new NumbersGameController(answersContainer);

            StartNewRound();
        }

        public void AddMessageListeners()
        {
            Func<ArrayList, bool> StartNewRoundInTimeDelegate = StartNewRoundInTime;
            Messenger.AddListener(MessageEnum.StartNewRoundInTime, StartNewRoundInTimeDelegate);
        }

        public void RemoveMessageListeners()
        {
            
        }

        private bool StartNewRoundInTime(ArrayList data)
        {
            Invoke("StartNewRound", (float)data[0]);
            return true;
        }
        private void StartNewRound()
        {
            numbersGameController.StartNewRound();
        }
    }
}
