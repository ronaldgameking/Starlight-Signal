using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]private GameObject Objective;
    [SerializeField]private Transform Player;
    [SerializeField]private Transform[] spawnOptions;

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

    /// <summary>
    /// Spawn the objective
    /// </summary>
    private void SpawnObjective()
    {
        Instantiate(Objective);
        GiveRandomPosition();
    } 

    /// <summary>
    /// Give it a random position
    /// </summary>
    private void GiveRandomPosition()
    {
        int randomSpawnOption = Random.Range(0, spawnOptions.Length);

        Vector3 pos = new Vector3(spawnOptions[randomSpawnOption].transform.position.x, transform.position.y, spawnOptions[randomSpawnOption].transform.position.z);

        Objective.transform.position = pos;
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
        Gizmos.color = Color.green;
       
        if(Objective != null && Player !=null)
        Gizmos.DrawLine(Objective.transform.position , Player.transform.position);

        
        Gizmos.color = Color.red;
        if (Objective != null && Player != null)
            Gizmos.DrawWireSphere(Objective.transform.position, maxDistance);
    }
}
