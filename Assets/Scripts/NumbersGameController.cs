using mvreylib.features.messenger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGameController
{
    private int rightAnswer;


    public void Execute()
    {
        //TODO : Dis 3 is config
        List<int> answers = GenerateAnswers(3);
        rightAnswer = answers[Random.Range(0, answers.Count)];

        string statement = GenerateNumberWord(rightAnswer);

        Messenger.SendMessage(MessageEnum.SetStatementText, new ArrayList() { statement });
        Messenger.SendMessage(MessageEnum.ShowStatement);

        Messenger.SendMessage(MessageEnum.SetAnswers, new ArrayList() { answers });
    }

    public string GenerateNumberWord(int number)
    {
        return "CINCO";
    }

    public List<int> GenerateAnswers(int amount)
    {
        List<int> answers = new List<int>();

        for (int i = 0; i < amount; i++)
        {
            //TODO : Min & max are config
            answers.Add(Random.Range(0, 11));
        }

        return answers;
    }
}
