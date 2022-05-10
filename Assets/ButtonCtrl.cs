using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject UIPanel;
    public GameObject GameNamePanel;

    [SerializeField]
    List<Resolution> resolutions = new List<Resolution>();

    [SerializeField]
    private Slider MouseSenSlider;
    [SerializeField]
    SettingsManager settingMg;

    public Dropdown resolutionDropdown;
    int resolutionNum;
    FullScreenMode screenMode;
    public Toggle fullscreenBtn;

    public Button applyButton;


    private void Start()
    {
        MouseSenSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("SensitiveSlider").GetComponent<Slider>();
        fullscreenBtn = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("FullScreenToggle").GetComponent<Toggle>();
        resolutionDropdown = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("ResolutionDropdown").GetComponent<Dropdown>();
        applyButton = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("SettingsApplyButton").GetComponent<Button>();
        settingMg = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();

        fullscreenBtn.isOn = false;

        InitUI();
    }

    private void Update()
    {
        //settingMg.ChangeMouseSen(settingMg.MouseSensitivity);
        //MouseSenSlider.onValueChanged.AddListener(ChangeMouseSen);
    }



    public void QuitButton()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    System.Diagnostics.Process.GetCurrentProcess().Kill();
#else
        Application.Quit();
#endif
    }

    public void StartButton()
    {
        SceneLoader.LoadScene("GameScene");
        //SceneManager.LoadScene("GameScene");
    }

    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
        UIPanel.SetActive(false);
        GameNamePanel.SetActive(false);
    }

    public void SettingsExit()
    {
        SettingsPanel.SetActive(false);
        UIPanel.SetActive(true);
        GameNamePanel.SetActive(true);
    }

    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width,
            resolutions[resolutionNum].height,
            screenMode);
        settingMg.SaveSen();
    }

    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].height <= 1080)
                resolutions.Add(Screen.resolutions[i]);
        }
        resolutionDropdown.options.Clear(); // options > List함수라서 초기 자료들 리셋


        /*
        foreach(Resolution item in resolutions)
        {
            Debug.Log(item.width + "x" + item.height +" " + item.refreshRate);//refreshRate >> 화면재생빈도
        }
        */

        int optionNum = 0;

        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
                resolutionDropdown.value = optionNum;
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue();

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void ChangeMouseSen(float mSen)
    {

        PlayerPrefs.GetFloat("MouseSensitivity", mSen);
        //settingMg.MouseSensitivity = mSen;
        MouseSenSlider.minValue = 0f;
        MouseSenSlider.maxValue = 4f;
        MouseSenSlider.value = mSen;
        //settingMg.SaveSen();
        PlayerPrefs.SetFloat("MouseSensitivity", mSen);
    }
}
