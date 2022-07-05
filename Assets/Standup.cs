using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standup : MonoBehaviour
{
    public GameObject V5;
    public GameObject PlayerLight;
    public GameObject guideUI;
    
    public void ChangeToStart()
    {
        V5.SetActive(false);
        Camera.main.cullingMask = Camera.main.cullingMask & ~(1 <<LayerMask.NameToLayer("Player"));
        PlayerLight.SetActive(true);
        guideUI.SetActive(true);
    }
}
