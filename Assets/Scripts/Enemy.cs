using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    [SerializeField] GameObject target;
    [SerializeField] LayerMask bulletmask;
    [SerializeField] GameObject enemyPrefab;
    bool alive;

    // Start is called before the first frame update
    void OnEnable()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        { 
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            Vector3 floor = new Vector3(0, transform.position.y , 0);
            transform.position -= floor;
            transform.LookAt(target.transform);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CheckLayerInMask(bulletmask, collision.gameObject.layer))
        {

            ObjectPool.Instance.ReturnToQueue("Enemy", enemyPrefab);

            alive = false;

            enemyPrefab.SetActive(false);
            Bullet.score++;
        }

    }
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
