using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public float MouseSensitivity = 2f;
    public float LightIntensity;
    public float ListenSound;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
