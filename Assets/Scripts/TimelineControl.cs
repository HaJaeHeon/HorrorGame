using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TimelineControl : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject PDCanvas;
    

    public void PlayerKill()
    {
        Debug.Log("PlayerKill");
        //Time.timeScale = 0f;
        //playableDirector.gameObject.SetActive(false);
        PDCanvas.SetActive(true);
        playableDirector.Pause();
    }
}
