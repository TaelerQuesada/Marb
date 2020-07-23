using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Animations;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{

    public Transform follow;
    public float turnSpeed = 5f;
    public float camDistance = 10f;

    private Vector3 offset;
    private float currentX = 0f;
    private float currentY = 0f;

    public float sensitivityX = 5f;
    public float sensitivityY = 5f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
    }
    void LateUpdate()
    {

        Vector3 direction = new Vector3(0f, 0f, -camDistance);
        Quaternion rotation = Quaternion.Euler(currentY * sensitivityY, currentX * sensitivityX, 0f);
        transform.position = follow.position + rotation * direction;
        transform.LookAt(follow.position);
    }
}
