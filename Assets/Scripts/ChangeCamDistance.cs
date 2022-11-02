using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamDistance : MonoBehaviour
{
    [SerializeField]
    private int distance;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Camera.main.gameObject.GetComponent<CamFollow>().distance = distance;
        }
    }
}
