using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private SettingsManager stMgr;
    public GameObject surpDool;

    private void Start()
    {
        source = gameObject.transform.GetComponent<AudioSource>();
        stMgr = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();
    }

    private void Update()
    {
        PlaySurpSound();
    }

    void PlaySurpSound()
    {
        if(surpDool.activeSelf == true)
        {
            source.volume = stMgr.Volumn;
            source.Play();
        }
    }
}
