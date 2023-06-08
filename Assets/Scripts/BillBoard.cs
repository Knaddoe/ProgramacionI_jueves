using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        Vector3 rot = target.eulerAngles;
        rot = Camera.main.transform.eulerAngles;
        rot.z = 0;
        target.transform.eulerAngles = rot;
    }
}
