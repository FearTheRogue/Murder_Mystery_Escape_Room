﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItems : MonoBehaviour
{
    public float rotationSpeed = 20;

    public void OnMouseDrag()
    {
        Debug.Log("This is being called");

        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, rotY);
    }
}
