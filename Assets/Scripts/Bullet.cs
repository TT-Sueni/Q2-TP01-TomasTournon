
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float speed;
    Rigidbody rb;
    [SerializeField] LayerMask enemyMask;
    private Vector3 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody>();



    }


    void Update()
    {
        if (target)
        {
            direction = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * (speed * Time.deltaTime));
        }
        else
        {
            
            rb.MovePosition(rb.position + direction * (speed* Time.deltaTime));
            Debug.Log("no posee target");
        }



    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (CheckLayerInMask(enemyMask, collision.gameObject.layer))
        {
            Debug.Log("pego contra " + collision.gameObject.layer);
            Destroy(rb.gameObject);
        }

    }
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
