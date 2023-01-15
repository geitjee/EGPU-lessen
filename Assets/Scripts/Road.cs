using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadType
{
    STRAIGHT,
    TURN,
    OBSTICAL,
    QUESTION,
}

public class Road : MonoBehaviour
{
    public RoadType type;
    public GameObject endPoint;
    public GameObject rightEndPoint = null;
    public RoadQuestions question = null;
}
