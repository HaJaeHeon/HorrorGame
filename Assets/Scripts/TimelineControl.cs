using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineControl : MonoBehaviour
{
    public PlayableDirector playableDirector;
    
    

    public void PlayerKill()
    {
        Debug.Log("PlayerKill");
        //Time.timeScale = 0f;
        playableDirector.gameObject.SetActive(false);
    }
}
