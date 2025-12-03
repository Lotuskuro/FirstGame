using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public EnemyData Edata;
    public GameObject EnemyToSpawn;


    public float spawnInterval = 1f;
    private float spawnTimer = 0f;
    
    

    void Awake()
    {
        Edata = ScriptableObject.CreateInstance<EnemyData>();
        Edata.targetPrefab = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
       
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Spawner();
            
            spawnTimer = 0f;
        }
        
    }
    public void Spawner() 
    {
       Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-10f, 10f));
       Instantiate(EnemyToSpawn, spawnPosition, Quaternion.identity);
    }
    
 


}
