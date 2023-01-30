using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionRoad : MonoBehaviour
{
    public TextMeshPro question;
    public TextMeshPro anwserLeft;
    public TextMeshPro anwserRight;

    /// <summary>
    /// Sets the text on the signs.
    /// </summary>
    /// <param name="questionText"></param>
    public void SetQuestion(string questionText, string anwserLeftText, string awnserRightText)
    {
        question.text = questionText;
        anwserLeft.text = anwserLeftText;
        anwserRight.text = awnserRightText;
    }
}
