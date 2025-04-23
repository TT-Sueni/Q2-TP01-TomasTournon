
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
   
    [SerializeField] private GameObject enemy;
    [SerializeField] private bool canSpawn;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;
     static Vector3 spawnlocation; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetSpawnLocation();
        Spawn();
       
    }
    private void Spawn()
    {
        if (!canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenSpawns)
            {
                canSpawn = true;
                timer = 0;
            }

        }
        if (canSpawn)
        {
            canSpawn = false;
            GameObject currentEnemy = ObjectPool.Instance.SpawnFromPool("Enemy", spawnlocation, Quaternion.identity);
            GameObject currentCitizen = ObjectPool.Instance.SpawnFromPool("Citizen", -spawnlocation, Quaternion.identity);


        }
        
    }

    static void SetSpawnLocation()
    {

        var randomLocation = new Vector3(Random.Range(1f, 10f), 0, Random.Range(1f, 10f));

        spawnlocation = randomLocation;

    }
    


   
}
