using System.Collections;
using UnityEngine;
using UnityUtils;

[RequireComponent(typeof(ObjectPool))]
public class RockGenerator : MonoBehaviour
{
    public ObjectPool Pool;

    [Header("Area where the rocks will spawn")]
    [SerializeField] private Vector3 SpawnArea = new Vector3(0, 0, 0);
    [Header("Spawn Data")]
    [SerializeField]private int objectAmount;
    [Tooltip("time when a new object is spawned")]
    [SerializeField]private float spawnTime = 10f;

    private Vector3 randomPos;
    private float m_timer;

    private void Start()
    {
        SpawnRocks();
    }

    private void Update()
    {
        if (m_timer >= spawnTime)
        {
            SpawnRocks();
            m_timer = 0;
        }
        m_timer += Time.deltaTime;
    }

    /// <summary>
    /// Instantiate with new rocks
    /// </summary>
    /// <param name="prefab"> the object you want to instantiate</param>
    private void SpawnRocks() 
    { 
        for (int i = 0; i < objectAmount; i++)
        {
            NewRandomPosition();
            Pool.PopObject(randomPos, Quaternion.identity);
        }
    }

    /// <summary>
    /// New randomposition
    /// </summary>
    private void NewRandomPosition()
    {
        float randomX = Random.Range(transform.position.x , SpawnArea.x);
        float randomY = Random.Range(SpawnArea.z - SpawnArea.z / 4, SpawnArea.z);
        float randomZ = Random.Range(transform.position.z , SpawnArea.z);

        randomPos = new Vector3(randomX, randomY, randomZ);
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
