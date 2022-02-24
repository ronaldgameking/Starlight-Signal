using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils;

public class RockBehaviour : MonoBehaviour
{
    [SerializeField]private float speed = 1;

    private PoolItem item;

    private void Update()
    {
        transform.Translate(0, -speed, 0);
    }

    private void Awake()
    {
        if (!TryGetComponent<PoolItem>(out item))
        {
            Debug.LogError("Cannot get poolitem");
        }
        //Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        item.ReturnToSender();
    }
}
