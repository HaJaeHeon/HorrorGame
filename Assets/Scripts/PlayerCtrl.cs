using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    private Rigidbody rb;

    [SerializeField]
    private FollowCam cameraCtrl;
    [SerializeField]
    private Transform camTr;
    CharacterController characterController;
    Animator ani;

    public float moveSpeed = 5f;
    private float gravity = -9.81f;
    private Vector3 moveDirection;



    public float rotSpeed = 2f;
    public float h = 0f, v = 0f;
    public float turnSpeed = 2f;

    public Vector3 moveVec;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        characterController = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
        cameraCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCam>();
    }

    private void Update()
    {
        GetInput();
        MovePlayer();
        RotateCam();
        GetGravity();
    }

    public void GetInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        

        MoveTo(new Vector3(h, 0, v));
    }

    void GetGravity()
    {
        if(characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
    }

    void MovePlayer()
    {
        //moveVec = new Vector3(h, 0, v);
        //tr.position += moveVec.normalized * moveSpeed * Time.deltaTime;
        //rb.MovePosition(tr.position + moveVec);

        /*Vector3 moveHorizontal = tr.right * h;
        Vector3 moveVertical = tr.forward * v;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * moveSpeed;

        rb.MovePosition(tr.position + velocity * Time.deltaTime);*/

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        if (h != 0 || v !=0)
        {
            ani.SetBool("Walk_Forward", true);
        }
    }

    public void MoveTo(Vector3 direction)
    {
        //moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
        Vector3 moveDis = camTr.rotation * direction;
        moveDirection = new Vector3(moveDis.x, moveDirection.y, moveDis.z).normalized;
    }

    //void RotateCamY()
    //{
    //    float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
    //    float yRotate = tr.eulerAngles.y + yRotateSize;

    //    transform.eulerAngles = new Vector3(0, yRotate, 0);

    //    if (moveVec == Vector3.zero) return;

    //    Quaternion rot = Quaternion.LookRotation(moveVec);
    //    rb.rotation = Quaternion.Slerp(rb.rotation, rot, rotSpeed * Time.deltaTime);
    //}

    void RotateCam()
    {
        float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

        //cameraCtrl.RotateTo(/*mouseX,*/mouseY);

        transform.Rotate(0, mouseX, 0);
    }
}
