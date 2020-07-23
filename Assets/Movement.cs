using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public GameObject follow;
    public Transform cam;
    public float speed = 6f;
    public float jump = 7f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");


        Transform hold = cam;
        Vector3 eulerRotation = hold.rotation.eulerAngles;
        hold.rotation = Quaternion.Euler(0f, eulerRotation.y, eulerRotation.z);
        Vector3 camFront = hold.forward;

        
        Vector3 moveRelativeVertical = camFront * Input.GetAxis("Vertical") 
            + hold.right * Input.GetAxis("Horizontal");
 
        rb.AddForce(moveRelativeVertical * speed);

        follow.transform.position = transform.position;

    }
}
