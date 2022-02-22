using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float rb_vl = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

#if !ENABLE_INPUT_SYSTEM
    private void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = input * Time.fixedDeltaTime * rb_vl;
        //rb.MovePosition(transform.position + input * Time.deltaTime * rb_vl);
    }
#endif
}
