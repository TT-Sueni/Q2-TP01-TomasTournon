using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    [SerializeField] private LayerMask bulletMask;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private bool canSpawn;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Vector3 spawnlocation = new(1,1,1);
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            Instantiate(enemy, spawnlocation, Quaternion.identity);
        }
        
    }

   
}
