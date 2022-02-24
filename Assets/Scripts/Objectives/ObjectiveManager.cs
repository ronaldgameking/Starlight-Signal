using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]public GameObject Objective;
    [SerializeField]private Transform Player;
    [SerializeField]private Transform[] spawnOptions;

    [SerializeField]private float distanceBetweenObjective;
    [SerializeField]private float maxDistance = 10f;

    [SerializeField]private int spawnOrder;

    bool startObjective;

    private void Awake()
    {
        SpawnObjective();

        DontDestroyOnLoad(this);
        Player = GameObject.Find("Player").transform;

        if (Player != null)
            startObjective = true;
        else
            startObjective = false;
    }

    private void Update()
    {
        if (Player != null)
        {
            CheckDistance(Objective.transform, Player);

            if (distanceBetweenObjective < maxDistance)
                ReachedTarget();
        }
    }

    /// <summary>
    /// Spawn the objective
    /// </summary>
    private void SpawnObjective()
    {
        GiveNextPosition(spawnOrder);
        Instantiate(Objective);
    } 

    /// <summary>
    /// Give it a random position
    /// </summary>
    private void GiveNextPosition(int orer)
    {
        //int randomSpawnOption = Random.Range(0, spawnOptions.Length);

        Vector3 pos = new Vector3(spawnOptions[orer].transform.position.x, spawnOptions[orer].transform.position.y, spawnOptions[orer].transform.position.z);

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
        Player = GameObject.Find("Player").transform;

        if (spawnOrder == spawnOptions.Length)
            return;

        spawnOrder = spawnOrder + 1;

        if (Player != null)
        SpawnObjective();
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
