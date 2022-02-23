using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]private Transform player;

    private void Update()
    {
        if (player != null)
            transform.LookAt(player);
        
    }
}
