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
    [SerializeField] public Camera cam;
    [SerializeField] public GameObject FPScam;
    [SerializeField] public GameObject thirdPersoncam;
    [SerializeField] public Transform attackPoint;
    bool FPS;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
        CameraSwitch();
    }
    private void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //rayo en el medio de la camara
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
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
            Bullet currentBullet =  ObjectPool.Instance.Get<Bullet>();
            currentBullet.gameObject.SetActive(true);
            currentBullet.transform.position = attackPoint.position;
            currentBullet.transform.rotation = Quaternion.identity;


            currentBullet.transform.forward = direction.normalized;
            
            
            currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);


        }

    }
    private void CameraSwitch() // arreglar
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && FPS)
        {
            FPScam.SetActive(true);
            thirdPersoncam.SetActive(false);
           
            FPS = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && !FPS)
        {
            thirdPersoncam.SetActive(true);
            FPScam.SetActive(false);
            FPS = true;
        }
    }

}
