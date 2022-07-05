using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchB : MonoBehaviour
{
    public bool blue = false;

    void Start()
    {
        blue = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            blue = true;
            Debug.Log("bb");
        }
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.tag == "Player")
    //    {
    //        gameObject.SetActive(false);
    //        blue = true;
    //        Debug.Log("BB");
    //    }
    //}
}
