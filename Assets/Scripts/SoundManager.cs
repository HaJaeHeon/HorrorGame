using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    #region singleton

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
            Destroy(instance);
    }
    #endregion singleton

    //public AudioSource source;
    public AudioSource BgmSource;
    public SettingsManager stMgr;

    public AudioClip bgm1;
    public AudioClip bgm2;

    private void Start()
    {
        stMgr = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();
        BgmStart();
        BgmSource.Play();
    }

    private void Update()
    {
        //if(BgmSource.volume != stMgr.Volumn)
        BgmSource.volume = stMgr.Volumn;
        BgmStop();
    }

    private void BgmStart()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "AnotherStartScene")
        {
            BgmSource.volume = stMgr.Volumn;
            BgmSource.clip = bgm1;
            BgmSource.Play();
            //BgmSource.UnPause();
        }

        else if(sceneName == "GameScene")
        {
            BgmSource.volume = stMgr.Volumn;
            BgmSource.clip = bgm2;
            BgmSource.Play();
            //BgmSource.UnPause();
            //Debug.Log(11);
        }
    }

    private void BgmStop()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "LoadingScene")
        {
            BgmSource.Stop();
            //Debug.Log(22);
        }
        else if (sceneName == "AnotherStartScene")
        {
            BgmSource.clip = bgm1;
            if (!BgmSource.isPlaying)
            {
                BgmSource.Play();
                //Debug.Log(44);
            }
        }
        else if (sceneName == "GameScene")
        {
            BgmSource.clip = bgm2;
            if (!BgmSource.isPlaying)
            {
                BgmSource.Play();
                //Debug.Log(55);
            }
        }

        
    }


    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.volume = stMgr.Volumn;
        audiosource.Play();

        Destroy(go, clip.length);

    }
}


//    public static SoundManager instance;

//    public AudioSource[] audioSourceEffects;
//    public AudioSource[] audioSourceBgm;

//    public AudioSource

//    public string[] playSoundName;

//    public Sound[] effectSounds;
//    public Sound[] bgmSounds;






//    private void Start()
//    {
//        playSoundEffectsName = new string[audioSourceEffects.Length];
//        playBackgroundSoundName = new string[audioSourceBgm.Length];
//    }

//    public void PlaySoundEffects(string _name)
//    {
//        for (int i = 0; i < effectSounds.Length; i++)
//        {
//            if (_name == effectSounds[i].name)
//            {
//                for (int j = 0; j < audioSourceEffects.Length; j++)
//                {
//                    if (!audioSourceEffects[j].isPlaying)
//                    {
//                        playSoundEffectsName[j] = effectSounds[i].name;
//                        audioSourceEffects[j].clip = effectSounds[i].clip;
//                        audioSourceEffects[j].Play();
//                        return;
//                    }
//                }
//                Debug.Log("모든 SE Audio Source 사용중");
//                return;
//            }
//        }
//        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
//    }

//    public void PlayBackgroundSounds(string _name)
//    {
//        for (int i = 0; i < bgmSounds.Length; i++)
//        {
//            if (_name == bgmSounds[i].name)
//            {
//                for (int j = 0; j < audioSourceBgm.Length; j++)
//                {
//                    if (!audioSourceBgm[j].isPlaying)
//                    {
//                        playBackgroundSoundName[j] = bgmSounds[i].name;
//                        audioSourceBgm[j].clip = bgmSounds[i].clip;
//                        audioSourceBgm[j].Play();
//                        return;
//                    }
//                }
//                Debug.Log("모든 Bgm Audio Source 사용중");
//                return;
//            }
//        }
//    }

//    public void StopAllSE()
//    {
//        for (int i = 0; i < audioSourceEffects.Length; i++)
//        {
//            audioSourceEffects[i].Stop();
//        }
//    }

//    public void StopSE(string _name)
//    {
//        for (int i = 0; i < audioSourceEffects.Length; i++)
//        {
//            if (playSoundEffectsName[i] == _name)
//            {
//                audioSourceEffects[i].Stop();
//                break;
//            }
//        }
//        Debug.Log("재생 중인" + _name + "사운드가 없습니다.");
//    }

//[System.Serializable]
//public class Sound
//{
//    public string name;
//    public AudioClip clip;
//}



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





