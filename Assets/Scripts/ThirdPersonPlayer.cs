using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayer : MonoBehaviour
{
    public float Speed = 120f;
	public InputHelper Helper;

    private Rigidbody rb;
    private Camera mainCam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector3 input = new Vector3(Helper.MoveDelta.x, 0, Helper.MoveDelta.y);
        Vector3 moveDir = Vector3.zero;
        if (input.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + mainCam.transform.eulerAngles.y;
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        rb.velocity = moveDir * Time.fixedDeltaTime * Speed;
    }
}
