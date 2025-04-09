
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;
    Rigidbody rb;
    [SerializeField] LayerMask playerMask;

    private void Awake()
    {
        if (cam == null)
            cam = Camera.main;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
        //rb.velocity = new Vector2(direction.x,direction.y).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = GetMousePosition();
        Vector3 direction = (mousePos - transform.position).normalized;
        rb.AddForce(direction * speed, ForceMode.Acceleration);

    }
    private Vector3 GetMousePosition()
    {
        Vector3 position;
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity))
        {
            position = hitInfo.point;
            //position.Normalize();
            return position;

        }
        else
        {
            return Vector3.zero;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(!CheckLayerInMask(playerMask, collision.gameObject.layer))
        {

            Destroy(rb.gameObject);
        }
        
    }
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
