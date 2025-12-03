using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public EnemyData[] Edata;
    public float spawnInterval = 1f;
    private float spawnTimer = 0f;
    

    void Awake()
    {
        
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
       Instantiate(Edata[0].enemyPrefab, spawnPosition, Quaternion.identity);
        
            
        

    }
    
 


}
