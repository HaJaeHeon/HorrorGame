using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class SurpriseDool : MonoBehaviour
{
    //public GameObject dool;
    //public Transform dTransform;
    //public Animator ani;
    //public AnimationClip clip;

    //public GameObject player;



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("SurpArea"))
    //    {
    //        dool.SetActive(true);


    //        dTransform.position = gameObject.transform.position;

    //        dool.transform.LookAt(player.transform.position);

    //        dool.transform.position = new Vector3(dool.transform.position.x,
    //            dool.transform.position.y, dool.transform.position.z - 2f);

    //        ani.Play("Magician", -1, clip.length);

    //        dool.transform.localScale =  new Vector3(Mathf.Lerp(0, 1, clip.length),
    //            Mathf.Lerp(0, 1, clip.length), Mathf.Lerp(0, 1, clip.length));
    //        //dool.transform.localScale = new Vector3(Mathf.Lerp(0, 1, Time.deltaTime),
    //        //    Mathf.Lerp(0, 1, Time.deltaTime), Mathf.Lerp(0, 1, Time.deltaTime));
    //    }
    //}

    public PlayableDirector playableDirector;
    public AudioSource surpSource;
    [SerializeField]
    private SettingsManager stMgr;

    private void Start()
    {
        stMgr = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SurpArea"))
        {
            surpSource.volume = stMgr.Volumn;
            surpSource.Play();
            playableDirector.Play();            
        }
    }
}
