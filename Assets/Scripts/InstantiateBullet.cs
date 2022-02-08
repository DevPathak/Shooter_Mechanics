using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour
{
    public static InstantiateBullet Instance;

    public GameObject projectileBullet;
    public Transform bulletSpawner;
    public float bulletSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            TwoDimAnimationController.Instance.SetAnimation("isShooting", true);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject bullet = Instantiate(projectileBullet, bulletSpawner.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.forward * bulletSpeed);
            }
        }
   
        else
        {
            TwoDimAnimationController.Instance.SetAnimation("isShooting", false);
        }
    }
}
