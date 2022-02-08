using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform neckBone;
    public float offSet;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = (transform.up * offSet) + neckBone.position;
        
    }
}
