using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    static public SettingsManager instance;

    public float MouseSensitivity/* = 2f*/;
    public float LightIntensity/* = 50f*/;
    public float Volumn/* = 0.500f*/;

    [SerializeField]
    private Slider MouseSenSlider;
    [SerializeField]
    private Slider LightIntenSlider;
    [SerializeField]
    private Slider VolumnSlider;


    #region singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
            Destroy(gameObject);
        
    }
    #endregion singleton

    private void Start()
    {

        if (!PlayerPrefs.HasKey("MouseSensitivity"))
        {
            PlayerPrefs.SetFloat("MouseSensitivity", 2f);
            LoadSen();
        }
        else
            LoadSen();

        if (!PlayerPrefs.HasKey("LightIntensity"))
        {
            PlayerPrefs.SetFloat("LightIntensity", 50f);
            LoadIntensity();
        }
        else
            LoadIntensity();

        if (!PlayerPrefs.HasKey("Volumn"))
        {
            PlayerPrefs.SetFloat("Volumn", 0.500f);
            LoadVolumn();
        }
        else
            LoadVolumn();


        //FindApplyButton();
        //FindSlider();
        //FindResoultionDropdown();
    }

    private void Update()
    {
        //if(resolutionDropdown == null)
        //    FindResoultionDropdown();
        //if (MouseSenSlider == null)
        //    FindSlider();
        //if (applyButton == null)
        //    FindApplyButton();

        //AnotherSetting();
        FindSlider();
        FindIntenSlider();
        FindVolumnSlider();
    }



    public void LoadSen()
    {
        //MouseSenSlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
        MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
    }

    public void SaveSen()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", MouseSenSlider.value);
        //PlayerPrefs.Save();

    }


    private void FindSlider()
    {
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
        }
        LoadSen();
    }


    public void LoadIntensity()
    {
        LightIntensity = PlayerPrefs.GetFloat("LightIntensity");
    }

    public void SaveIntensity()
    {
        PlayerPrefs.SetFloat("LightIntensity", LightIntenSlider.value);
    }

    private void FindIntenSlider()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "AnotherStartScene")
        {
            LightIntenSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("LightSlider").GetComponent<Slider>();
        }
        else if (sceneName == "GameScene")
        {
            LightIntenSlider = GameObject.Find("UICanvas")
            .transform.Find("SettingPanel").transform.Find("LightSlider").GetComponent<Slider>();
        }
        LoadIntensity();
    }


    public void LoadVolumn()
    {
        Volumn = PlayerPrefs.GetFloat("Volumn");
    }

    public void SaveVolumn()
    {
        PlayerPrefs.SetFloat("Volumn", VolumnSlider.value);
    }

    private void FindVolumnSlider()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "AnotherStartScene")
        {
            VolumnSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("VolumnSlider").GetComponent<Slider>();
        }
        else if (sceneName == "GameScene")
        {
            VolumnSlider = GameObject.Find("UICanvas")
            .transform.Find("SettingPanel").transform.Find("VolumnSlider").GetComponent<Slider>();
        }
        LoadVolumn();
    }






    //public void ChangeMouseSen(float mSen)
    //{
    //    //if (MouseSenSlider == null)
    //    //    FindSlider();
    //    //MouseSensitivity = mSen;
    //    MouseSenSlider.minValue = 0f;
    //    MouseSenSlider.maxValue = 4f;
    //    MouseSenSlider.value = mSen;
    //    SaveSen();
    //}

    //private void AnotherSetting()
    //{
    //    Scene currentScene = SceneManager.GetActiveScene();

    //    string sceneName = currentScene.name;

    //    if(sceneName == "AnotherStartScene")
    //    {
    //        if (fullscreenBtn.onValueChanged == null)
    //            fullscreenBtn.onValueChanged
    //                .AddListener(FullScreenBtn);

    //        if (resolutionDropdown.onValueChanged == null)
    //            resolutionDropdown.onValueChanged
    //                .AddListener(DropboxOptionChange);
    //        if (applyButton.onClick == null)
    //            applyButton.onClick.AddListener(OkBtnClick);
    //        applyButton.onClick.AddListener(OkBtnClick);
    //    }
    //}

    //void InitUI()
    //{
    //    for(int i = 0; i < Screen.resolutions.Length; i++)
    //    {
    //        if (Screen.resolutions[i].height <= 1080)
    //            resolutions.Add(Screen.resolutions[i]);
    //    }
    //    resolutionDropdown.options.Clear(); // options > List함수라서 초기 자료들 리셋


    //    /*
    //    foreach(Resolution item in resolutions)
    //    {
    //        Debug.Log(item.width + "x" + item.height +" " + item.refreshRate);//refreshRate >> 화면재생빈도
    //    }
    //    */

    //    int optionNum = 0;

    //    foreach(Resolution item in resolutions)
    //    {
    //        Dropdown.OptionData option = new Dropdown.OptionData();
    //        option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
    //        resolutionDropdown.options.Add(option);

    //        if (item.width == Screen.width && item.height == Screen.height)
    //            resolutionDropdown.value = optionNum;
    //        optionNum++;
    //    }
    //    resolutionDropdown.RefreshShownValue();

    //    fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    //}

    //public void DropboxOptionChange(int x)
    //{
    //    resolutionNum = x;
    //}

    //public void FullScreenBtn(bool isFull)
    //{
    //    screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    //}


    /*
    private void FindResoultionDropdown()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "AnotherStartScene")
        {
            resolutionDropdown = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("ResolutionDropdown").GetComponent<Dropdown>();
            fullscreenBtn = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("FullScreenToggle").GetComponent<Toggle>();

            InitUI();
        }
    }
    */
    /*
    private void FindApplyButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "AnotherStartScene")
        {
            applyButton = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("SettingsApplyButton").GetComponent<Button>();
        }
    }
    */

}
