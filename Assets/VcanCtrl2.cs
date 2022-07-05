using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcanCtrl2 : MonoBehaviour
{
    public GameObject Vcam7;
    public GameObject Vcam8;
    public GameObject Vcam9;

    private void Update()
    {
        inTimeline();
    }

    private void inTimeline()
    {
        if (Vcam7.activeSelf == true)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Monster");
            Camera.main.cullingMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Player"));
        }
        else if (Vcam8.activeSelf == true)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
            Camera.main.cullingMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Monster"));
        }
        else if (Vcam9.activeSelf == true)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Monster");
        }
        else if (Vcam7.activeSelf == false && Vcam8.activeSelf == false && Vcam9.activeSelf == false)
        {
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Monster");
            Camera.main.cullingMask = Camera.main.cullingMask & ~LayerMask.NameToLayer("Player");
        }
    }
}
