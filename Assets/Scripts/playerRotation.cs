using UnityEngine;
using UnityEngine.UIElements;

public class playerRotation : MonoBehaviour
{

    [SerializeField] private float maxSpeed = 100f;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");
        //float z = 0;
        //Debug.Log("X: " + x + "\nY: " + y);

        if (Mathf.Abs(x) < 0.01f && Mathf.Abs(y) < 0.01f)
            return;


        Vector3 direction = (Vector3.up * y + Vector3.right * x);
        //direction.z = 0;
        //rb.AddTorque(direction * maxSpeed, ForceMode.Acceleration);
        direction.y *= maxSpeed;
        direction.x *= maxSpeed;
        direction.z = 0;
        transform.Rotate(direction);


    }

}
