using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] audioSourceEffects;
    public AudioSource audioSourceBgm;

    public string[] playSoundName;

    public Sound[] effectSounds;
    public Sound[] bgmSounds;

    #region singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);
    }
    #endregion singleton

    private void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }

    public void PlaySoundEffects(string _name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if(!audioSourceEffects[j].isPlaying)
                    {
                        playSoundName[j] = effectSounds[i].name;
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 Audio Source 사용중");
                return;
            }
            if(_name == bgmSounds[i].name)
            {

            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }
    public void StopAllSE()
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                break;
            }
        }
        Debug.Log("재생 중인" + _name + "사운드가 없습니다.");
    }

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }



    //private void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(instance);
    //        SceneManager.sceneLoaded += onsceneLoaded;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //private void onsceneLoaded(Scene arg0, LoadSceneMode arg1)
    //{
    //    for(int i = 0; i < BgList.Length; i++)
    //    {
    //        if(arg0.name == BgList[i].name)
    //            BackGroundSoundPlay(BgList[i]);

    //    }
    //}

    //public void SFXPlay(string sfxName, AudioClip clip)
    //{
    //    GameObject go = new GameObject(sfxName + "Sound");
    //    AudioSource audioSource = go.AddComponent<AudioSource>();
    //    audioSource.clip = clip;
    //    audioSource.Play();

    //    Destroy(go, clip.length);
    //}

    //public void BackGroundSoundPlay(AudioClip clip)
    //{
    //    BgSound.clip = clip;
    //    BgSound.loop = true;
    //    BgSound.volume = 0.1f;
    //    BgSound.Play();
    //}
}

