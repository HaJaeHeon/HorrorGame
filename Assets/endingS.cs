using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class endingS : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public PlayerRay pr;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EndArea"))
        {
            if (pr.exit == true)
            {
                playableDirector.Play();
            }
        }
    }
}
