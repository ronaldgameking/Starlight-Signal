using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpeed : MonoBehaviour
{
    [SerializeField]private float speed = 5f;

    private void FixedUpdate()
    {
        //Constant speed forward
        transform.position += Vector3.forward * speed * Time.deltaTime;

        //Get horizontal speed
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }
}
