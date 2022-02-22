using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
