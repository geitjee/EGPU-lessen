using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.root.tag == "Player")
        {
            this.gameObject.GetComponent<TimeManager>().Finished();
        }
    }
}
