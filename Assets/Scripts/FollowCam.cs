using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float dist = 10.0f;
    public float height = 5.0f;
    public float smoothRotate = 5f;

    public float turnSpeed = 4f;

    private float xRotate = 0f;

    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        float CurrYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y,
            smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, CurrYAngle, 0);

        tr.position = target.position - (rot * Vector3.forward * dist)
            + (Vector3.up * height);

        RotateCam();
        
    }

    void RotateCam()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
}
