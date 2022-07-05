using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePaperOn : MonoBehaviour
{
    public GameObject bPaper;
    public GameObject bText;

    public bool uiBOff = false;


    private void Update()
    {
        if (bPaper.activeSelf == false && uiBOff == false)
        {
            printBluePaper();
        }
    }


    private void printBluePaper()
    {
        bText.SetActive(true);
        uiBOff = true;
        //Debug.Log("YP");
    }
}
