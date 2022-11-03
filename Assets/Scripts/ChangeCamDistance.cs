using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamDistance : MonoBehaviour
{
    [SerializeField]
    private int distance;

    /// <summary>
    /// Checks if the player is in the trigger and then changes the following distance .
    /// (this was done because the first ramp would stop the camera from seeing the car)
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Camera.main.gameObject.GetComponent<CamFollow>().distance = distance;
        }
    }
}
