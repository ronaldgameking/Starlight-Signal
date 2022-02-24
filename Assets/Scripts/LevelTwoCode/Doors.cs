using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject doorPart_bottom;
    [SerializeField] private GameObject doorPart_Up;

    [SerializeField] private Transform player;

    [SerializeField]private float openDistance = 5f;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(doorPart_bottom.transform.position , player.position);

        if (dist < openDistance)
        {
            animator.SetBool("Open", true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(doorPart_bottom.transform.position, new Vector3(openDistance, openDistance, openDistance) );
    }
}
