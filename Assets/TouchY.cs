using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchY : MonoBehaviour
{
    public bool yellow = false;

    void Start()
    {
        yellow = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            yellow = true;
            //Debug.Log("yy");
        }
    }

}
