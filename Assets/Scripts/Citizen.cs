using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [SerializeField] GameObject target;
    [SerializeField] LayerMask bulletmask;
    [SerializeField] GameObject citizenPrefab;
    bool alive;

    // Start is called before the first frame update
    void OnEnable()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            Vector3 floor = new Vector3(0, transform.position.y, 0);
            transform.position -= floor;
            transform.LookAt(target.transform);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CheckLayerInMask(bulletmask, collision.gameObject.layer))
        {

            ObjectPool.Instance.ReturnToQueue("Citizen", citizenPrefab);

            alive = false;
            citizenPrefab.SetActive(false);
            Bullet.score--;
        }

    }
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
