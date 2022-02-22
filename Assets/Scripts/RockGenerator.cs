using System.Collections;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    [Header("Rocks")]
    [SerializeField]private GameObject rockprefab;
    [Header("Area where the rocks will spawn")]
    [SerializeField] private Vector3 SpawnArea = new Vector3(0, 0, 0);
    [Header("Spawn Data")]
    [SerializeField]private int objectAmount;
    [Tooltip("time when a new object is spawned")]
    [SerializeField]private float spawnTime = 10f;

    private Vector3 randomPos;

    private void Awake()
    {
        SpawnRocks(rockprefab);
        StartCoroutine("SpawnObjects");
    }

    /// <summary>
    /// Instantiate with new rocks
    /// </summary>
    /// <param name="prefab"> the object you want to instantiate</param>
    private void SpawnRocks(GameObject prefab) 
    { 
        for (int i = 0; i < objectAmount; i++)
        {
           NewRandomPosition();
           Instantiate(prefab);
           prefab.transform.position = new Vector3(randomPos.x, randomPos.y , randomPos.z);
        }
    }

    /// <summary>
    /// New randomposition for the y and z axis
    /// </summary>
    private void NewRandomPosition()
    {
        float randomX = Random.Range(transform.position.x , SpawnArea.x);
        float randomY = Random.Range(SpawnArea.z - SpawnArea.z / 4, SpawnArea.z);
        float randomZ = Random.Range(transform.position.z , SpawnArea.z);

        randomPos = new Vector3(randomX, randomY, randomZ);
        print(randomPos);
    }
    
    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnRocks(rockprefab);
        StartCoroutine("SpawnObjects");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawLine(new Vector3(transform.position.x , transform.position.y, transform.position.z),
            new Vector3(transform.position.x + SpawnArea.x , transform.position.y, transform.position.z));// X axis
        Gizmos.DrawLine(new Vector3(transform.position.x , transform.position.y, transform.position.z),
            new Vector3(transform.position.x ,transform.position.y + SpawnArea.y, transform.position.z));// Y axis
        Gizmos.DrawLine(new Vector3(transform.position.x , transform.position.y, transform.position.z),
            new Vector3(transform.position.x , transform.position.y,transform.position.z + SpawnArea.z));// Z axis
    }
}
