﻿using innovamattest.componentviews;
using UnityEngine;

namespace innovamattest.configs
{
    [CreateAssetMenu(fileName = "InnovamatTestConfig", menuName = "ScriptableObjects/InnovamatTestConfig", order = 1)]
    public class InnovamatTestConfig : ScriptableObject
    {
        [Header("Prefabs")]
        public StatementComponentView statementPrefab;
        public AnswerComponentView answerPrefab;

        [Header("Numerical Configs")]
        public int numAnswers = 3;
    }
}