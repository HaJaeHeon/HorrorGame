using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPaperOn : MonoBehaviour
{
    public GameObject endPaper;
    public GameObject endText;
    //public PlayerRay pr;

    public bool uiEOff = false;


    private void Update()
    {
        if (endPaper.activeSelf == false && uiEOff == false /*&& pr.exit == true*/)
        {
            printEndPaper();
        }
        //Debug.Log(uiGOff);
    }


    private void printEndPaper()
    {
        endText.SetActive(true);
        uiEOff = true;
        //Debug.Log("YP");
        //Debug.Log("1");
    }
}
