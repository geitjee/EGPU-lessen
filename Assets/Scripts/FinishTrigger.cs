using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class FinishTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.root.CompareTag("Player"))
        {
            collider.transform.root.GetComponent<CarAudio>().StopSound();
            this.gameObject.GetComponent<TimeManager>().Finished();
        }
    }
}
