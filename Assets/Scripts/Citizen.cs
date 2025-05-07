using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : BaseEnemy
{
    Citizen citizen;
    [SerializeField] GameObject citizenHolder;

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
    public override void GetObjectFromPool()
    {
        //citizen = ObjectPool.Instance.Get<Citizen>();
    }
    public override void SetParent()
    {
        transform.parent = citizenHolder.transform;
    }
    public override void ResetToDefault()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Bullet.CheckLayerInMask(bulletMask, collision.gameObject.layer))
        {

            ObjectPool.Instance.ReturnToPool<Citizen>(citizen);

            isAlive = false;
            
            Bullet.score--;
        }

    }
   
}
