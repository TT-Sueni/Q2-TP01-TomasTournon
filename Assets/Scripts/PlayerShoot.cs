using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask destroyableLayer;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private bool canFire;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenShots;
    laser laser;

  
    private void Awake()
    {
        if (cam == null)
            cam = Camera.main;
        //laser.pointer = GetComponent<LineRenderer>();
    }
    void Update()
    {


        Shoot();
    }
    

    private void Shoot()
    {

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                canFire = true;
                timer = 0;
            }

        }
        //if (Input.GetMouseButtonDown(0) && canFire)
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out RaycastHit hit, 100,destroyableLayer ))
        //    {
        //        //Debug.Log(hit.transform.gameObject);
        //        Bullet bullet = Instantiate(bulletPrefab);
        //        bullet.SetTarget(hit.transform);
        //        bullet.transform.position = transform.position;
        //        canFire = false;
        //    }
        //}
     
    }


}
