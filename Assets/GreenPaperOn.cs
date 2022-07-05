using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPaperOn : MonoBehaviour
{
    public GameObject gPaper;
    public GameObject gText;

    public bool uiGOff = false;


    private void Update()
    {
        if (gPaper.activeSelf == false && uiGOff == false)
        {
            printGreenPaper();
        }
        //Debug.Log(uiGOff);
    }


    private void printGreenPaper()
    {
        gText.SetActive(true);
        uiGOff = true;
        //Debug.Log("YP");
        //Debug.Log("1");
    }
}
