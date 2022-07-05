using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseSig : MonoBehaviour
{
    public GameObject Dool;

    public void OnDool()
    {
        Dool.SetActive(true);
    }


    public void OffDool()
    {
        Dool.SetActive(false);
    }
}
