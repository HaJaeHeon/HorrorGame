using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperY : MonoBehaviour
{
    public GameObject paperYellow;
    //public GameObject TextYellow;

    public GameObject target;

    private void Update()
    {
        ViewPaper();
    }

    void ViewPaper()
    {
        Debug.Log("11");
        if (paperYellow.activeSelf == false)
        {
            Debug.Log("YPaper");
            target.SendMessage("printYellowPaper");
        }

    }
}
