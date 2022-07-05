using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamCtrl : MonoBehaviour
{
    public GameObject Vcam2;
    public GameObject Vcam3;
    public GameObject Vcam4;

    public GameObject Vcam7;
    public GameObject Vcam8;
    public GameObject Vcam9;

    private void Update()
    {
        inTimeline();
    }
    
    void inTimeline()
    {
        if (Vcam2.activeSelf == true || Vcam7.activeSelf == true)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Monster");
            Camera.main.cullingMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Player"));
        }
        else if (Vcam3.activeSelf == true || Vcam8.activeSelf == true)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
            Camera.main.cullingMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Monster"));
        }
        else if (Vcam4.activeSelf == true || Vcam9.activeSelf == true)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Monster");
        }
        else if (Vcam2.activeSelf == false && Vcam3.activeSelf == false && Vcam4.activeSelf == false
                    && Vcam7.activeSelf == false && Vcam8.activeSelf == false && Vcam9.activeSelf == false)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Monster");
            Camera.main.cullingMask = Camera.main.cullingMask & ~LayerMask.NameToLayer("Player");
        }
    }
}
