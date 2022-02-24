using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField]private float camSpeed = 4f;
    [SerializeField]private Vector3 offSet;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
