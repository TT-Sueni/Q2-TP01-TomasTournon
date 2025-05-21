
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{


    [SerializeField] private bool canSpawn;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;
    static Vector3 spawnLocationEnemy;
    static Vector3 spawnLocationCitizen;



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
            Enemy currentEnemy = ObjectPool.Instance.Get<Enemy>();
            

            currentEnemy.transform.position = spawnLocationEnemy;
            currentEnemy.gameObject.SetActive(true);
            var currentCitizen = ObjectPool.Instance.Get<Citizen>();
            currentCitizen.transform.position = spawnLocationCitizen;
            currentCitizen.gameObject.SetActive(true);
        }
        
    }

    static void SetSpawnLocation()
    {

        var randomLocationEnemy = new Vector3(30, 0, Random.Range(-20f, 30f));
        var randomLocationCitizen = new Vector3(-60, 0, Random.Range(-1f, 7f));

        spawnLocationEnemy = randomLocationEnemy;
        spawnLocationCitizen = randomLocationCitizen;
    }




}
