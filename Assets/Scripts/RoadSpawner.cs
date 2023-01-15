using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject theCar;
    private int minRoadRemoveDistance = 50;

    private int roadStartAmount = 10;
    private int minStraightroads = 3;
    private int maxStraightRoads = 15;
    private int maxRoadAmount = 50;

    public GameObject startingRoad;
    public List<GameObject> turningRoads;
    public List<GameObject> obsticalRoads;
    public List<GameObject> straightRoads;
    public GameObject quizRoad;

    private Road previousRoad;

    private List<GameObject> currentRoads;

    private int obsticalChance = 100;

    public RoadQuestions[] allQuestions;

    /// <summary>
    /// Function that runs before the scene gets loaded.
    /// sets up the basic stuff and finds all the RoadQuestions ScriptableObjects.
    /// </summary>
    private void Awake()
    {
        if (theCar == null)
        {
            throw new System.Exception("ERROR: the car cannot be null!");
        }
        if (startingRoad == null)
        {
            throw new System.Exception("ERROR: there must be a starting road!");
        }
        previousRoad = startingRoad.GetComponent<Road>();

        //Code to find all the existing RoadQuestions.
        string[] a = AssetDatabase.FindAssets("t:" + typeof(RoadQuestions).Name);
        allQuestions = new RoadQuestions[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            allQuestions[i] = AssetDatabase.LoadAssetAtPath<RoadQuestions>(AssetDatabase.GUIDToAssetPath(a[i]));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRoads = new List<GameObject>();
        currentRoads.Add(startingRoad);

        Random.InitState(System.DateTime.Now.Millisecond);

        for (int i = 0; i < roadStartAmount; i++)
        {
            SpawnRoad(startingRoad);
        }
        SpawnRoad(SelectRandomRoad(true));
    }

    private void SpawnRoad(GameObject road)
    {
        if (previousRoad.endPoint == null)
        {
            throw new System.Exception("ERROR: no endpoint!");
        }
        if (previousRoad.GetComponent<Road>().type == RoadType.QUESTION)
        {
            if (previousRoad.question == null)
            {
                throw new System.Exception("ERROR: question is null can't determine correct path.");
            }
            if (previousRoad.rightEndPoint == null)
            {
                throw new System.Exception("ERROR: no second endpoint for question!.");
            }
            if (previousRoad.question.anwserLeft.isCorrect)
            {
                Instantiate(road, previousRoad.rightEndPoint.transform.position, Quaternion.identity).GetComponent<Road>();
                previousRoad = Instantiate(road, previousRoad.endPoint.transform.position, Quaternion.identity).GetComponent<Road>();
            }
            else if (previousRoad.question.anwsersRight.isCorrect)
            {
                Instantiate(road, previousRoad.endPoint.transform.position, Quaternion.identity).GetComponent<Road>();
                previousRoad = Instantiate(road, previousRoad.rightEndPoint.transform.position, Quaternion.identity).GetComponent<Road>();
            }
            else
            {
                throw new System.Exception("ERROR: no correct anwser!");
            }

            for (int i = 0; i < Random.Range(minStraightroads, maxStraightRoads-2); i++)
            {
                SpawnRoad(SelectRandomRoad(false));
            }
            SpawnRoad(SelectRandomRoad(true));
        }
        else
        {
            Quaternion newRoadRotation = road.transform.rotation * previousRoad.endPoint.transform.rotation;
            previousRoad = Instantiate(road, previousRoad.endPoint.transform.position, newRoadRotation).GetComponent<Road>();
            currentRoads.Add(previousRoad.gameObject);
        }
    }

    private void SpawnQuizRoad()
    {
        Quaternion newRoadRotation = quizRoad.transform.rotation * previousRoad.endPoint.transform.rotation;
        //Determine the difficulty that the question should be.
        RoadQuestions question = allQuestions[Random.RandomRange(0, allQuestions.Length)];

        previousRoad = Instantiate(quizRoad, previousRoad.endPoint.transform.position, newRoadRotation).GetComponent<Road>();
        currentRoads.Add(previousRoad.gameObject);
        //currentRoadLocation += Vector3.Scale(previousRoad.GetComponent<Renderer>().bounds.size, currentRoadDirection);
    }

    private GameObject SelectRandomRoad(bool isTurn)
    {
        if (isTurn)
        {
            return turningRoads[Random.Range(0, turningRoads.Count)];
        }
        else
        {
            if (Random.Range(0, obsticalChance) > 90)
            {
                return obsticalRoads[Random.Range(0, obsticalRoads.Count)];
            }
            else
            {
                return straightRoads[Random.Range(0, straightRoads.Count)];
            }
        }
    }

    private void Update()
    {
        if (currentRoads.Count >= maxRoadAmount)
        {
            if (Vector3.Distance(currentRoads[0].transform.position, theCar.transform.position) > minRoadRemoveDistance)
            {
                Destroy(currentRoads[0]);
                currentRoads.Remove(currentRoads[0]);
            }
        }
        if (currentRoads.Count < maxRoadAmount)
        {
            for (int i = 0; i < Random.Range(minStraightroads, maxStraightRoads); i++)
            {
                SpawnRoad(SelectRandomRoad(false));
            }
            SpawnRoad(SelectRandomRoad(true));
        }
        //This if statement is just here in case it goes wrong and the road ahead is ending (:
        if (Vector3.Distance(currentRoads[currentRoads.Count-1].transform.position, theCar.transform.position) < 20)
        {
            SpawnRoad(SelectRandomRoad(false));
        }
    }
}
