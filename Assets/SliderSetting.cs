using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderSetting : MonoBehaviour
{
    [SerializeField]
    SettingsManager settingMgr;
    [SerializeField]
    Slider MouseSenSlider;
    [SerializeField]
    Toggle fullscreenToggle;
    [SerializeField]
    Dropdown resolutionDropdown;
    [SerializeField]
    Button applyButton;

    float MouseSen;
    // Start is called before the first frame update
    void Start()
    {
        settingMgr = GameObject.Find("SettingsMgr").gameObject.GetComponent<SettingsManager>();
        //MouseSenSlider = gameObject.GetComponent<Slider>();
        


        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "AnotherStartScene")
        {
            MouseSenSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("SensitiveSlider").GetComponent<Slider>();
        }
        else if (sceneName == "GameScene")
        {
            MouseSenSlider = GameObject.Find("UICanvas")
            .transform.Find("SettingPanel").transform.Find("SensitiveSlider").GetComponent<Slider>();
            //MouseSenSlider = gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Slider>();
        }
        
        MouseSen = settingMgr.MouseSensitivity;
        MouseSenSlider.minValue = 0f;
        MouseSenSlider.maxValue = 4f;
        MouseSenSlider.value = MouseSen;
        MouseSenSlider.onValueChanged.AddListener(ChangeMSen);
        //MouseSenSlider.onValueChanged.AddListener(delegate { ChangeMSen(MouseSen); });
    }


    // Update is called once per frame
    void Update()
    {
        if (MouseSenSlider.onValueChanged == null)
            MouseSenSlider.onValueChanged
                //.AddListener(delegate { settingMgr.ChangeMouseSen(MouseSen); });
                .AddListener(ChangeMSen);
        

    }

    private void ChangeMSen(float mSen)
    {
         settingMgr.MouseSensitivity = mSen;
         MouseSenSlider.minValue = 0f;
         MouseSenSlider.maxValue = 4f;
         MouseSenSlider.value = mSen;
         settingMgr.SaveSen();
    }
}
