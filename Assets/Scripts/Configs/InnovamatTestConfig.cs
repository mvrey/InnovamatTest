using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InnovamatTestConfig", menuName = "ScriptableObjects/InnovamatTestConfig", order = 1)]
public class InnovamatTestConfig : ScriptableObject
{
    public StatementComponentView statementPrefab;
    public AnswerComponentView answerPrefab;
}