using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    private Rigidbody rb;

    CapsuleCollider col;

    public float moveSpeed = 2f;
    public float rotSpeed = 2f;
    public float h = 0f, v = 0f;
    public float turnSpeed = 2f;

    public Vector3 moveVec;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        GetInput();
        MovePlayer();
        RotateCamY();
    }

    void GetInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");


    }

    void MovePlayer()
    {
        //moveVec = new Vector3(h, 0, v);
        //tr.position += moveVec.normalized * moveSpeed * Time.deltaTime;
        //rb.MovePosition(tr.position + moveVec);

        Vector3 moveHorizontal = tr.right * h;
        Vector3 moveVertical = tr.forward * v;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * moveSpeed;

        rb.MovePosition(tr.position + velocity * Time.deltaTime);

    }

    void RotateCamY()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = tr.eulerAngles.y + yRotateSize;

        transform.eulerAngles = new Vector3(0, yRotate, 0);

        if (moveVec == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(moveVec);
        rb.rotation = Quaternion.Slerp(rb.rotation, rot, rotSpeed * Time.deltaTime);
    }
}
