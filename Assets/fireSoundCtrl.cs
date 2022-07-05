using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSoundCtrl : MonoBehaviour
{
    [SerializeField]
    private SettingsManager stMgr;
    [SerializeField]
    private AudioSource source;

    private void Start()
    {
        stMgr = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        source.volume = stMgr.Volumn;
    }
}
