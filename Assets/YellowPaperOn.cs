using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPaperOn : MonoBehaviour
{
    public GameObject yPaper;
    public GameObject yText;

    public bool uiYOff = false;


    private void Update()
    {
        if(yPaper.activeSelf == false && uiYOff == false)
        {
            printYellowPaper();
        }
    }


    private void printYellowPaper()
    {
        yText.SetActive(true);
        uiYOff = true;
        //Debug.Log("YP");
    }
}
