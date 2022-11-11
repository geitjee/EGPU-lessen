using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Vehicles.Car;

public class QuizScript : MonoBehaviour
{
    public enum QuestionFunction {Add, Substract, Multiply, Divide}

    [Serializable]
    public class QuizQuestion
    {
        public float num1;
        public QuestionFunction function;
        public float num2;
    }
    public TextMeshProUGUI powerText;

    public QuizQuestion[] quizQuestions;

    public GameObject quizMenu;
    public GameObject questionInstance;
    private List<GameObject> questionsList;
    
    private int currentQuestion;
    private int correctAnswerCount = 0;
    private CarUserControl carControl;

    /// <summary>
    /// Creates the quiz in the canvas from the given input to the quizManager (or the object that has this script).
    /// </summary>
    void Awake()
    {
        carControl = FindObjectOfType(typeof(CarUserControl)) as CarUserControl;
        carControl.speedMultiplier = 0.8f;
        powerText.text = String.Format("Car power: {0}%", (carControl.speedMultiplier * 100));
        if (quizQuestions.Length == 0)
        {
            quizMenu.SetActive(false);
            return;
        }
        questionsList = new List<GameObject>();
        Time.timeScale = 0;
        correctAnswerCount = 0;
        currentQuestion = 0;
        for (int i = 0; i < quizQuestions.Length; i++)
        {
            QuizQuestion curQuestion = quizQuestions[i];
            GameObject g = Instantiate(questionInstance, quizMenu.transform);

            //Change Title
            string progressTxt = "Question " + (i + 1) + "/" + quizQuestions.Length;
            g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = progressTxt;

            //Change Question
            string sumStr = "";
            switch (curQuestion.function)
            {
                case QuestionFunction.Add:
                    sumStr = "+";
                    break;
                case QuestionFunction.Substract:
                    sumStr = "-";
                    break;
                case QuestionFunction.Multiply:
                    sumStr = "*";
                    break;
                case QuestionFunction.Divide:
                    sumStr = "/";
                    break;
            }
            string questionTxt = String.Format("{0} {1} {2}", curQuestion.num1, sumStr, curQuestion.num2);
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = questionTxt;

            //Set Button correct
            g.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate { AnwserQuestion(); });

            g.SetActive(false);
            questionsList.Add(g);
        }
        questionsList[0].SetActive(true);
        quizMenu.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Checks the questions anwser and goes to the next question or starts the quiz.
    /// </summary>
    public void AnwserQuestion()
    {
        bool correctAnswer = false;
        QuizQuestion curQuestion = quizQuestions[currentQuestion];
        switch (curQuestion.function)
        {
            case QuestionFunction.Add:
                correctAnswer = CalculatorScript.AddNumbers(curQuestion.num1, curQuestion.num2).ToString().Equals(questionsList[currentQuestion].transform.GetChild(2).GetComponent<TMP_InputField>().text);
                break;
            case QuestionFunction.Substract:
                correctAnswer = CalculatorScript.SubstractNumbers(curQuestion.num1, curQuestion.num2).ToString().Equals(questionsList[currentQuestion].transform.GetChild(2).GetComponent<TMP_InputField>().text);
                break;
            case QuestionFunction.Multiply:
                correctAnswer = CalculatorScript.MultiplyNumbers(curQuestion.num1, curQuestion.num2).ToString().Equals(questionsList[currentQuestion].transform.GetChild(2).GetComponent<TMP_InputField>().text);
                break;
            case QuestionFunction.Divide:
                correctAnswer = CalculatorScript.DivideNumbers(curQuestion.num1, curQuestion.num2).ToString().Equals(questionsList[currentQuestion].transform.GetChild(2).GetComponent<TMP_InputField>().text);
                break;
        }
        StartCoroutine(ChangeBackground(correctAnswer));
        if (correctAnswer)
        {
            correctAnswerCount++;
            carControl.speedMultiplier += 0.2f * (1 / (float)quizQuestions.Length);
            powerText.text = String.Format("Car power: {0}%", (carControl.speedMultiplier * 100));
        }
        if (currentQuestion < quizQuestions.Length - 1)
        {
            //Next question.
            questionsList[currentQuestion].SetActive(false);
            currentQuestion++;
            questionsList[currentQuestion].SetActive(true);
        }
        else
        {
            //Quiz is over.
            quizMenu.SetActive(false);
            Time.timeScale = 1;
        }

    }

    /// <summary>
    /// Function to show if the answer was correct or wrong by changing the background green or red for half a second.
    /// </summary>
    /// <param name="isCorrect">Bool if the answer was correct or not.</param>
    /// <returns></returns>
    IEnumerator ChangeBackground(bool isCorrect)
    {
        if (isCorrect)
        {
            quizMenu.GetComponent<RawImage>().color = Color.green;
            yield return new WaitForSecondsRealtime(0.5f);
            quizMenu.GetComponent<RawImage>().color = Color.white;
        }
        else
        {
            quizMenu.GetComponent<RawImage>().color = Color.red;
            yield return new WaitForSecondsRealtime(0.5f);
            quizMenu.GetComponent<RawImage>().color = Color.white;
        }
    }
}
