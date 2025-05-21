
using UnityEngine;


public class Bullet : MonoBehaviour, IPooleable
{
    [SerializeField] static Vector3 target;

    [SerializeField] private float speed;
    Rigidbody rb;
    [SerializeField] LayerMask enemyMask;
    private Vector3 direction;

    static public int score = 0;
    [SerializeField] GameObject magazine;
    Bullet bullet;


    void Awake()
    {


        rb = GetComponent<Rigidbody>();

    }



    public static void SetTarget(Vector3 target2)
    {
        target = target2;
    }


    public void GetObjectFromPool()
    {
        //bullet = ObjectPool.Instance.Get<Bullet>();
    }


    void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.transform.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.DestroyObject();
            ReturntoPool();
        }



        if (CheckLayerInMask(enemyMask, collision.gameObject.layer))
        {

            ReturntoPool();

        }

    }



    public void ResetToDefault()
    {
        bullet.rb.velocity = Vector3.zero;
        bullet.rb.angularVelocity = Vector3.zero;
    }

    public void SetParent()
    {
        transform.parent = magazine.transform;
    }
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    public void ReturntoPool()
    {
        ObjectPool.Instance.ReturnToPool<Bullet>(bullet);
        Destroy(bullet);

    }
}
