using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;



public class Shooting : MonoBehaviour
{
    

    //bullet force
    [SerializeField] float shootForce;


    //Reference
    [SerializeField] public Camera Cam;
    [SerializeField] public Transform attackPoint;
    

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
    }
    private void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //rayo en el medio de la camara
            Ray ray = Cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
            RaycastHit hit;

            //checkea si el rayo le pego a algo
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(75); 

            //direccion

            Vector3 direction = targetPoint - attackPoint.position;





            //Instantiate bullet/projectile
            GameObject currentBullet = ObjectPool.Instance.SpawnFromPool("Bullet", attackPoint.position, Quaternion.identity);
            

            currentBullet.transform.forward = direction.normalized;
            
            
            currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);


        }

    }

}
