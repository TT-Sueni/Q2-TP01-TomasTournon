
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] static Vector3 target;

    [SerializeField] private float speed;
    Rigidbody rb;
    [SerializeField] LayerMask enemyMask;
    private Vector3 direction;
    [SerializeField] GameObject bullet;
    static public int score = 0;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        
    }
    public static  void SetTarget(Vector3 target2)
    {
        target = target2;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (CheckLayerInMask(enemyMask, collision.gameObject.layer))
        {
            
            ObjectPool.Instance.ReturnToQueue("Bullet",bullet);
            bullet.SetActive(false);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            
        }

    }
    public static  bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
   
}
