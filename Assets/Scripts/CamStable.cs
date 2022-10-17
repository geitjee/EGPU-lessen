using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStable : MonoBehaviour
{
    public GameObject theCar;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float CarX = theCar.transform.eulerAngles.x;
        float CarY = theCar.transform.eulerAngles.y;
        float CarZ = theCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX - CarX, CarY, CarZ - CarZ);
    }
}
