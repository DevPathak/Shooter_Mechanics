using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var hitObjectRef = collision.collider.gameObject;

        Debug.Log(hitObjectRef.tag);

        if (hitObjectRef != null && hitObjectRef.tag == "IsHitable")
        {
            Destroy(hitObjectRef);
        }

        Destroy(this.gameObject);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(transform.position, 0.1f);
    //}
}
