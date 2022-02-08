using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] movingPoints;
    public float speed;
    int trackpoint = 0;
    CharacterController cc;

    void Start()
    {
        //rb.constraints = RigidbodyConstraints.None;
    }

    void Update()
    {
        if (movingPoints.Length > 0)
        {
            if (movetoTarget(movingPoints[trackpoint]))
            {
                trackpoint++;

                if (trackpoint >= movingPoints.Length)
                {
                    trackpoint = 0;
                }
            }
        }
    }

    bool movetoTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        return Vector3.Distance(transform.position, target.position) < 0.01f;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
