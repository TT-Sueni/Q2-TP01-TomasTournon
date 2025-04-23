using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField] private Rigidbody playerPos;
    [SerializeField] public LineRenderer pointer;
    [SerializeField] private Vector3 origin;
    [SerializeField] public Vector3 end;
    [SerializeField] private float Width;

    // Start is called before the first frame update
    void Awake()
    {
        pointer = GetComponent<LineRenderer>();
        playerPos = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        LaserPosition();



    }

    public void LaserPosition()
    {
        pointer.startWidth = Width; 
        pointer.SetPosition(0, playerPos.transform.position + playerPos.transform.forward * 0.5f);
        origin = pointer.GetPosition(0);
        end = origin + playerPos.transform.forward * 9;
        pointer.SetPosition(1, end);
    }
    public Vector3 LaserEndPos() 
    {
        return end;
    }
}
