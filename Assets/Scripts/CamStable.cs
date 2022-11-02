using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStable : MonoBehaviour
{
    public GameObject theCar;
    // Update is called once per frame
    /// <summary>
    /// Makes sure the camera doesn't tilt over if the car does that.
    /// Only follows the Y rotation.
    /// </summary>
    void Update()
    {
        float CarX = theCar.transform.eulerAngles.x;
        float CarY = theCar.transform.eulerAngles.y;
        float CarZ = theCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX - CarX, CarY, CarZ - CarZ);
    }
}
