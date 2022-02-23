using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]private GameObject Objective;
    [SerializeField]private Transform Player;

    [SerializeField]private float distanceBetweenObjective;
    [SerializeField]private float maxDistance = 10f;

    private void Awake()
    {
        SpawnObjective();
    }

    private void Update()
    {
        CheckDistance(Objective.transform , Player);

        if (distanceBetweenObjective < maxDistance)
            ReachedTarget();
    }

    private void SpawnObjective()
    {
        Instantiate(Objective);
        GiveRandomPosition();
    } 

    private void GiveRandomPosition()
    {
        // create a few places where the objective can be spawned
        // let is choose between those position 
    }

    private void CheckDistance(Transform objective , Transform player)
    {
        distanceBetweenObjective = Vector3.Distance(objective.transform.position , player.transform.position);
    }

    private void ReachedTarget()
    {
        //Change to choosing a random level
        MenuManager.instance.LoadSceneByName("Level_One");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       
        if(Objective != null && Player !=null)
        Gizmos.DrawLine(Objective.transform.position , Player.transform.position);
    }
}
