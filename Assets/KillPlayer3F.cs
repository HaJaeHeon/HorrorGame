using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KillPlayer3F : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject PDCanvas;


    public void PlayerKill()
    {
        //Debug.Log("PlayerKill");
        PDCanvas.SetActive(true);
        playableDirector.Pause();
    }
}
