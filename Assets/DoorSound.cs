using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip openSound;
    public AudioClip closeSound;
    [SerializeField]
    private SettingsManager stMgr;

    private void Start()
    {
        stMgr = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();
        source = gameObject.transform.GetComponent<AudioSource>();
        source.pitch = 1.5f;
    }

    public void DoorOpeningSound()
    {
        source.volume = stMgr.Volumn;
        source.clip = closeSound;
        source.Play();
        //Debug.Log("11");
    }

    public void DoorClosingSound()
    {
        source.volume = stMgr.Volumn;
        source.clip = openSound;
        source.Play();
        //Debug.Log("22");
    }
}
