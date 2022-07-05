using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    Ray threadRay;
    Ray paperRay;
    Ray fireRay;
    RaycastHit hit;
    LayerMask Thread;

    public GameObject findTread;
    public GameObject findPaper;
    public GameObject IntoTheFire;

    public GameObject endPaper;

    //public YellowPaperOn YellowP;
    //public GreenPaperOn GreenP;
    //public BluePaperOn BlueP;

    public bool exit = false;

    public InvenOnOff ioo;

    //public GameObject YellowText;
    //public GameObject GreenText;
    //public GameObject BlueText;

    private void Update()
    {
        UpTreadUI();
        UpPaperUI();
        UpFireUI();
    }

    void UpTreadUI()
    {
        Vector3 rayPosition = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z);

        threadRay = new Ray(transform.position, transform.forward);

        //Debug.DrawRay(rayPosition, gameObject.transform.forward * 1.5f,
        //        Color.red);

        if (Physics.Raycast(rayPosition, gameObject.transform.forward,
            out hit, 1.5f, 1 << 8))
        {
            findTread.SetActive(true);
            //Debug.Log("find!");
            if (Input.GetKey(KeyCode.F))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
        else
        {
            findTread.SetActive(false);
        }
        //Debug.DrawRay(threadRay);
    }

    void UpPaperUI()
    {
        Vector3 rayPosition = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z);

        paperRay = new Ray(transform.position, transform.forward);

        //Debug.DrawRay(rayPosition, gameObject.transform.forward * 1.5f,
        //        Color.red);

        if (Physics.Raycast(rayPosition, gameObject.transform.forward,
            out hit, 1.5f, 1 << 9))
        {
            findPaper.SetActive(true);
            //Debug.Log("Paper!");
            if (Input.GetKey(KeyCode.F))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
        else
        {
            findPaper.SetActive(false);
        }
    }

    void UpFireUI()
    {
        Vector3 rayPosition = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z);

        fireRay = new Ray(transform.position, transform.forward);

        //Debug.DrawRay(rayPosition, gameObject.transform.forward * 1.5f,
        //        Color.blue);

        if (Physics.Raycast(rayPosition, gameObject.transform.forward,
            out hit, 1.5f, 1 << 10))
        {
            if (/*YellowP.uiYOff == true && GreenP.uiGOff == true && BlueP.uiBOff == true
                &&*/ ioo.yg == true && ioo.gg == true && ioo.bg == true)
            {
                IntoTheFire.SetActive(true);
                //Debug.Log("Throw Thread!");
                if (Input.GetKey(KeyCode.F))
                {
                    endPaper.SetActive(true);
                    exit = true;
                }
            }
        }
        else
        {
            IntoTheFire.SetActive(false);
        }
    }
}
