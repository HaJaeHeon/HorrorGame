using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public float MouseSensitivity = 2f;
    public float LightIntensity;
    public float ListenSound;
    public Scrollbar VScrollBar;
    public Scrollbar scrollbar;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeMouseSen()
    {
        //VScrollBar vScrollBar1 = new VScrollBar();
    }
}
