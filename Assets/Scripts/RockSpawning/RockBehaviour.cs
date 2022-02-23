using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils;

public class RockBehaviour : MonoBehaviour
{
    private PoolItem item;

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
