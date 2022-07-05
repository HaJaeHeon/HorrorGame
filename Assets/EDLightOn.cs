using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class EDLightOn : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject GOLight;
    public Light SLight;
    public GameObject PLight;

    public GameObject EndingCredit;
    public Animator endTxt;

    private void Update()
    {
        if(GOLight.activeSelf == true)
        {
            SLight.intensity += Mathf.Lerp(0f, 1f, 10f * Time.deltaTime);
        }
    }

    public void PlayerLightOff()
    {
        PLight.SetActive(false);
    }

    public void LightOn()
    {
        GOLight.SetActive(true);
    }

    public void GameEnd()
    {
        EndingCredit.SetActive(true);
        endTxt.Play("endingTxt");
    }
}
