using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomBall : MonoBehaviour
{
    private List<GameObject> notBalls;
    public Material[] materials;
    public GameObject[] balls;
    // Start is called before the first frame update
    private void Awake()
    {
    }

    void Start()
    {
        // InvokeRepeating("BallSpawner", 1, 0.5f);
        notBalls = new List<GameObject>();
    }

    /// <summary>
    /// For lessons changes all the spawned objects material on X.
    /// Spawns a new random object from the balls[] and gives it a random mass and drag.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i =0; i < notBalls.Count; i++) 
            {
                int r = Random.Range(0, materials.Length);
                notBalls[i].GetComponent<Renderer>().material = materials[r];

            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            int r = Random.Range(0, balls.Length);
            GameObject g = Instantiate(balls[r], new Vector3(0, 10, 0), balls[r].transform.rotation);
            notBalls.Add(g);
            int randomMass = Random.Range(0, 312);
            g.GetComponent<Rigidbody>().mass = randomMass;
            g.GetComponent<Rigidbody>().drag = Random.Range(0, 10);
            //Destroy(g, 10);
        }

        
    }

    public GameObject BallSpawner()
    {
        int r = Random.Range(0, balls.Length);
        GameObject g = Instantiate(balls[r], new Vector3(0, 10, 0), balls[r].transform.rotation);
        return g;
    }
}
