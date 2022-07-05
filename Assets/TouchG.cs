using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchG : MonoBehaviour
{
    public bool green = false;

    void Start()
    {
        green = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            green = true;
            //Debug.Log("gg");
        }
    }
}
