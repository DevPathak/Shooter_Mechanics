using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public Transform bullet;
    public bool debugMode;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || debugMode == true)
        {
            RayCastShoot();    
        }
    }

    void RayCastShoot()
    {
        if (Physics.Raycast(bullet.position, bullet.forward, out RaycastHit hitInfo, 100f))
        {
            var hitObjectRef = hitInfo.transform.gameObject;         
            Debug.DrawRay(bullet.position, bullet.forward * hitInfo.distance, Color.red);

            if (Input.GetKeyDown(KeyCode.Mouse0) && hitObjectRef != null && hitObjectRef.tag == "IsHitable")
            {
                Destroy(hitObjectRef, 0.2f);
            }
        }
        else
        {         
            Debug.DrawRay(bullet.position, bullet.forward * 1000, Color.green);
        }
    }
}
