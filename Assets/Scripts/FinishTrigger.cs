using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class FinishTrigger : MonoBehaviour
{
    /// <summary>
    /// Checks if the player crossed the finish and stops the car sound because this would get stuck when the time is paused.
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.root.CompareTag("Player"))
        {
            collider.transform.root.GetComponent<CarAudio>().StopSound();
            this.gameObject.GetComponent<TimeManager>().Finished();
        }
    }
}
