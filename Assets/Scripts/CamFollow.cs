using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public Transform player;
    public float distance = 18f;
    public float height = 14.5f;
    public float damping = 0.7f;
    public bool smoothRotation = true;
    public float rotationDamping = 50.0f;

    // Start is called before the first frame update
    /// <summary>
    /// Checks if there is a object with player tag and then assignes that as the object to follow.
    /// </summary>
    void Awake()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    /// <summary>
    /// Function to move from current position to the desired follow position.
    /// And makes sure the camera looks at the player object.
    /// </summary>
    void FixedUpdate()
    {
        Vector3 wantedPosition = player.TransformPoint(0, height, -distance);

        transform.position = Vector3.Lerp(transform.position, wantedPosition, damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(player.position - transform.position, player.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
        {
            transform.LookAt(player, player.up);
        }
    }
}
