using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject yellowG;
    
    [SerializeField]
    private GameObject greenG;
    
    [SerializeField]
    private GameObject blueG;
    

    [SerializeField]
    private Image ImageYellow;
    [SerializeField]
    private Image ImageGreen;
    [SerializeField]
    private Image ImageBlue;

    public bool yg = false;
    public bool gg = false;
    public bool bg = false;


    private void Awake()
    {


        //ImageYellow = gameObject.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>();
        //ImageGreen = gameObject.transform.GetChild(3).transform.GetChild(1).GetComponent<Image>();
        //ImageBlue = gameObject.transform.GetChild(3).transform.GetChild(2).GetComponent<Image>();


    }


    private void Update()
    {
        YellowOnOff();
        GreenOnOff();
        BlueOnOff();
    }


    void YellowOnOff()
    {
        //if (yellowS.yellow)
        if(yellowG.activeSelf == false)
        {
            ImageYellow.color = new Color(255,255,255);
            yg = true;
        }
    }

    void GreenOnOff()
    {
        if(greenG.activeSelf == false)
        {
            ImageGreen.color = new Color(255, 255, 255);
            gg = true;
        }
    }

    void BlueOnOff()
    {
        if(blueG.activeSelf == false)
        {
            ImageBlue.color = new Color(255, 255, 255);
            bg = true;
        }
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject == yellowG)
    //    {
    //        Debug.Log("Y");
    //        yellowS.yellow = true;
    //    }
    //    if (hit.gameObject == greenG)
    //    {
    //        greenS.green = true;
    //        Debug.Log("G");
    //    }
    //    if (hit.gameObject == blueG)
    //    {
    //        blueS.blue = true;
    //        Debug.Log("B");
    //    }
    //    //Rigidbody body = hit.collider.attachedRigidbody;
    //    //if (body == null || body.isKinematic)
    //    //    return;
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == yellowG)
    //    {
    //        yellowS.yellow = true;
    //        Debug.Log("y");
    //    }
    //    if (other.gameObject == greenG)
    //    {
    //        greenS.green = true;
    //        Debug.Log("g");
    //    }
    //    if (other.gameObject == blueG)
    //    {
    //        blueS.blue = true;
    //        Debug.Log("b");
    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == yellowG)
    //    {
    //        yellowS.yellow = true;
    //        Debug.Log("yyyy");
    //    }
    //    if (collision.gameObject == greenG)
    //    {
    //        greenS.green = true;
    //        Debug.Log("gggg");
    //    }
    //    if (collision.gameObject == blueG)
    //    {
    //        blueS.blue = true;
    //        Debug.Log("bbbb");
    //    }
    //}
   
}
