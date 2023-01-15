using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RunnerQuestion", menuName = "ScriptableObjects/RoadQuestion", order = 1)]
public class RoadQuestions : ScriptableObject
{
    public QuestionDifficulty difficulty;
    public QuizScript.QuizQuestion question;
    public QuestionAnwser anwserLeft;
    public QuestionAnwser anwsersRight;
}

[Serializable]
public class QuestionAnwser
{
    public bool isCorrect;
    public int anwser;
}

public enum QuestionDifficulty
{
    EASY,
    MEDIUM,
    HARD,
}
