using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //public Transform target;

    public SettingsManager SettingsMgr;

    //public float dist = 10.0f;
    //public float height = 5.0f;
    //public float smoothRotate = 5f;

    //public float turnSpeed = 4f;

    //private float xRotate = 0f;

    //private Transform tr;

    //private void Start()
    //{
    //    tr = GetComponent<Transform>();
    //}

    //private void Update()
    //{
    //    float CurrYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y,
    //        smoothRotate * Time.deltaTime);

    //    Quaternion rot = Quaternion.Euler(0, CurrYAngle, 0);

    //    tr.position = target.position - (rot * Vector3.forward * dist)
    //        + (Vector3.up * height);

    //    RotateCamX();

    //}

    //void RotateCamX()
    //{
    //    //float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
    //    //float yRotate = transform.eulerAngles.y + yRotateSize;

    //    float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;

    //    xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

    //    transform.eulerAngles = new Vector3(xRotate, target.transform.eulerAngles.y, 0);
    //}
    //[SerializeField]
    //private float rotateSpeedX = 3;
    //[SerializeField]
    //private float rotateSpeedY = 5;
    //[SerializeField]
    //private float limitMinX = -80;
    //[SerializeField]
    //private float limitMaxX = 50;
    //private float eulerAngleX;
    //private float eulerAngleY;

    //public void RotateTo(/*float mouseX,*/ float mouseY)
    //{
    //    //eulerAngleY += mouseX * rotateSpeedX;

    //    eulerAngleX -= mouseY * rotateSpeedY;

    //    eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

    //    transform.rotation = Quaternion.Euler(eulerAngleX, /*eulerAngleY,*/ 0, 0);
    //}

    //private float ClampAngle(float angle, float min, float max)
    //{
    //    if (angle < -360) angle += 360;
    //    if (angle > 360) angle -= 360;

    //    return Mathf.Clamp(angle, min, max);
    //}
    //public float camSensitivity = 2f;

    public float yMinLimit = -45f;
    public float yMaxLimit = 45f;

    private float currentCameraRotationY = 0f;

    private void Start()
    {
        SettingsMgr = GameObject.Find("SettingsMgr").gameObject.GetComponent<SettingsManager>();
    }

    private void Update()
    {
       CamRotation();
        //Debug.Log(SettingsMgr.MouseSensitivity);

        //Camera camera = GetComponent<Camera>();
        //float[] distances = new float[32]; 32개 레이어 설정
        //distances[10] = 15;               레이어들중 10번 레이어 값을 설정한다. >> 설정한 값 15보다 가까운 거리에서만 렌더링
        //camera.layerCullDistances = distances;  카메라의 layerCullDistances를 설정 
        
    }   

    public void CamRotation()
    {
        float YRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationY = YRotation * SettingsMgr.MouseSensitivity /*camSensitivity*/;
        currentCameraRotationY += cameraRotationY;

        currentCameraRotationY = Mathf.Clamp(currentCameraRotationY, -45f, 45f);

        transform.localEulerAngles = new Vector3(-currentCameraRotationY, 0f, 0f);
    }
}
