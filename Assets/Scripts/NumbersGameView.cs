using mvreylib.features.messenger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGameView : MonoBehaviour
{
    public Transform answersContainer;


    private void Start()
    {
        NumbersGameController numbersGameController = new NumbersGameController();

        numbersGameController.Execute();
    }
}
