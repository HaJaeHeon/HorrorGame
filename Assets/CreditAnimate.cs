using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditAnimate : MonoBehaviour
{
    public GameObject creditPanel;
    public Animator creditAni;

    private void Update()
    {
        if(creditPanel.activeSelf == true)
        {
            creditAni.Play("CreditAni");
        }
    }
}
