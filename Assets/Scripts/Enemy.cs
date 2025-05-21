using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : BaseEnemy 
{
    [SerializeField] GameObject enemySpawner;

    Enemy enemy;
    Bullet bullet;

    void OnEnable()
    {
        isAlive = true;
    }

   
    void Update()
    {
        if (isAlive)
        { 
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            Vector3 floor = new Vector3(0, transform.position.y, 0);
            transform.position -= floor;
            transform.LookAt(target.transform);
            
        }
    }
    public override void SetParent()
    {
        transform.parent = enemySpawner.transform;
    }
   
    public override void GetObjectFromPool()
    {
        //enemy = ObjectPool.Instance.Get<Enemy>(transform.position,Quaternion.identity);
    }

    public override void ResetToDefault()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {


        if (Bullet.CheckLayerInMask(bulletMask, collision.gameObject.layer))
        {
            ObjectPool.Instance.ReturnToPool<Enemy>(enemy);
            Bullet.score++;
            Debug.Log(Bullet.score);
            
            
            
        }
    }
  
    
}
