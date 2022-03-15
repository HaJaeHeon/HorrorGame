using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource BgSound;
    public AudioClip[] BgList;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += onsceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void onsceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for(int i = 0; i < BgList.Length; i++)
        {
            if(arg0.name == BgList[i].name)
                BackGroundSoundPlay(BgList[i]);

        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }

    public void BackGroundSoundPlay(AudioClip clip)
    {
        BgSound.clip = clip;
        BgSound.loop = true;
        BgSound.volume = 0.1f;
        BgSound.Play();
    }
}
