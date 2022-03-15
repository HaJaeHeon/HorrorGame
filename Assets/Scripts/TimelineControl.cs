using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineControl : MonoBehaviour
{
    public PlayableDirector playableDirector;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerKill()
    {
        Debug.Log("PlayerKill");
        Time.timeScale = 0f;
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
    }
}
