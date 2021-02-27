using mvreylib.features.messenger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGameController
{
    private List<int> answers;
    private int rightAnswer;
    private string statement;

    public int successes = 0;
    public int fails = 0;


    public void Execute()
    {
        //TODO : Dis 3 is config
        answers = GenerateAnswers(3);
        rightAnswer = answers[Random.Range(0, answers.Count)];

        statement = GenerateNumberWord(rightAnswer);
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


    public List<int> GetAnswers()
    {
        return answers;
    }
    public int GetRightAnswer()
    {
        return rightAnswer;
    }
    public string GetStatement()
    {
        return statement;
    }
}
