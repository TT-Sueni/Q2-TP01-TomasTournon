using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] Image playerLifebar;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] LayerMask obstacleMask;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (playerLifebar.fillAmount <= 0)
        {
            Destroy(rb.gameObject);
        }
    }
    private void FixedUpdate()
    {
        Movement();


    }
    private void Movement()
    {
        float z = Input.GetAxis("Vertical"); //SW
        float y = 0;
        float x = Input.GetAxis("Horizontal");// AD

        if (Input.GetKey(KeyCode.Space))
            y = 1;
        if (Input.GetKey(KeyCode.LeftControl))
            y = -1;


        if (Mathf.Abs(z) < 0.01f && Mathf.Abs(y) < 0.01f && Mathf.Abs(x) < 0.01f)
            return;
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * z + right * x + Vector3.up * y ).normalized;
        rb.AddForce(direction * speed, ForceMode.Acceleration);
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity * maxSpeed;
        

    }
    void OnCollisionEnter(Collision collision)
    {


        if (Bullet.CheckLayerInMask(enemyMask, collision.gameObject.layer))
        {


            playerLifebar.fillAmount -= 0.25f;




        }
        else if (Bullet.CheckLayerInMask(obstacleMask, collision.gameObject.layer))
        {
            playerLifebar.fillAmount -= 0.25f;
        }


    }
}
