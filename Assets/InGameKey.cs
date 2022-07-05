using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InGameKey : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingPanel;
    [SerializeField]
    GameObject GuideUI;
    [SerializeField]
    GameObject InventoryUI;
    [SerializeField]
    Slider MouseSenSlider;
    [SerializeField]
    SettingsManager settingMg;
    [SerializeField]
    Slider LightIntenSlider;
    [SerializeField]
    Image LightImage;
    [SerializeField]
    Slider VolumnSlider;


    [SerializeField]
    List<Resolution> resolutions = new List<Resolution>();
    public Dropdown resolutionDropdown;
    int resolutionNum;
    FullScreenMode screenMode;
    public Toggle fullscreenBtn;

    public Button applyButton;

    //int timer;

    public bool check = true;

    private void Awake()
    {
        //SettingPanel = GameObject.Find("UICanvas")
        //    .transform.GetChild(1).gameObject;
        //GuideUI = GameObject.Find("UICanvas")
        //    .transform.GetChild(2).gameObject;
        //InventoryUI = GameObject.Find("UICanvas")
        //    .transform.GetChild(3).gameObject;
    }
    void Start()
    {
        MouseSenSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("SensitiveSlider").GetComponent<Slider>();
        LightIntenSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("LightSlider").GetComponent<Slider>();

        settingMg = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();

        LightImage = GameObject.Find("LightPanel").GetComponent<Image>();

        VolumnSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("VolumnSlider").GetComponent<Slider>();

        //settingMg.LoadSen();
        MouseSenSlider.minValue = 0f;
        MouseSenSlider.maxValue = 4f;
        MouseSenSlider.value = settingMg.MouseSensitivity;

        LightIntenSlider.minValue = 0f;
        LightIntenSlider.maxValue = 125f;
        LightIntenSlider.value = settingMg.LightIntensity;

        VolumnSlider.minValue = 0f;
        VolumnSlider.maxValue = 1f;
        VolumnSlider.value = settingMg.Volumn;

        InitUI();
    }

    void Update()
    {
        //if (SettingPanel.activeSelf == false)
        //    Invoke("PressEsc", 0.1f);
        //else if (SettingPanel.activeSelf == true)
        //    PressEsc();
        PressEsc();
    }

    private void FixedUpdate()
    {
        //PressEsc();
        PressTab();
        //settingMg.ChangeMouseSen(settingMg.MouseSensitivity);
        MouseSenSlider.onValueChanged.AddListener(ChangeMouseSen);
        //stopUI();
        LightIntenSlider.onValueChanged.AddListener(ChangeLightIntensity);
        VolumnSlider.onValueChanged.AddListener(ChangeVolumn);        
    }


    void PressEsc()
    {
        //Debug.Log("0");
        if (Input.GetKeyDown(KeyCode.Escape) /*&& check*/)
        {
            //Debug.Log("1");

            if (SettingPanel.activeSelf == false)
            {
                SettingPanel.SetActive(true);
                Time.timeScale = 0f;
                check = false;
                Cursor.visible = true;
                //StartCoroutine(WaitForUI());
                Invoke("PressEsc", 0.1f);
                //Debug.Log("2");
            }
            else if (SettingPanel.activeSelf == true)
            {
                SettingPanel.SetActive(false);
                Time.timeScale = 1f;
                check = false;
                Cursor.visible = false;
                //StartCoroutine(WaitForUI());
                Invoke("PressEsc", 0.1f);
                //Debug.Log("3");

            }
        }
        
    }

    //void stopUI()
    //{
    //    timer += (int)Time.unscaledDeltaTime;
    //    check = true;
    //    Debug.Log("123");
    //}

    void PressTab()
    {
        if (Input.GetKey(KeyCode.Tab)/* && check*/)
        {
            //check = false;
            //if (InventoryUI.activeSelf == false)
            //{
            //    InventoryUI.SetActive(true);
            //}
            //else if(InventoryUI.activeSelf == true)
            //{
            //    InventoryUI.SetActive(false);
            //}
            //StartCoroutine(WaitForUI());

            InventoryUI.SetActive(true);
            if (InventoryUI.transform.position.x < -10)
                InventoryUI.transform.position =
                    new Vector3(InventoryUI.transform.position.x + 1200f * Time.deltaTime,
                                InventoryUI.transform.position.y);
        }
        else if(!Input.GetKey(KeyCode.Tab))
        {
            if(InventoryUI.transform.position.x > -450 )
            InventoryUI.transform.position = 
                new Vector3(InventoryUI.transform.position.x - 1200f * Time.deltaTime,
                            InventoryUI.transform.position.y);
            else if(InventoryUI.transform.position.x < -450)
                InventoryUI.SetActive(false);
        }
    }


    //IEnumerator WaitForUI()
    //{
    //    //Time.timeScale = Time.timeScale * Time.deltaTime;
    //    //yield return new WaitForSeconds(0.5f);
    //    //yield return new WaitForSecondsRealtime(0.5f);
    //    //yield return new WaitForFixedUpdate();
    //    yield return new WaitForEndOfFrame();
    //    check = true;
    //}
    

    public void GuideUIExitButton()
    {
        GuideUI.SetActive(false);
    }

    public void ChangeMouseSen(float mSen)
    {
        //if (MouseSenSlider == null)
        //    FindSlider();
        //MouseSensitivity = mSen;
        //if (!PlayerPrefs.HasKey("MouseSensitivity"))
        //{
        //    PlayerPrefs.SetFloat("MouseSensitivity", 2f);
        //    settingMg.LoadSen();
        //}
        PlayerPrefs.GetFloat("MouseSensitivity", mSen);
        MouseSenSlider.minValue = 0f;
        MouseSenSlider.maxValue = 4f;
        MouseSenSlider.value = mSen;
        //settingMg.SaveSen();
        PlayerPrefs.SetFloat("MouseSensitivity", mSen);
    }

    public void ChangeLightIntensity(float LI)
    {
        PlayerPrefs.GetFloat("LightIntensity", LI);
        LightIntenSlider.minValue = 0f;
        LightIntenSlider.maxValue = 125f;
        LightIntenSlider.value = LI;
        PlayerPrefs.SetFloat("LightIntensity", LI);
        Color color = LightImage.color;
        color.a = (125-LI) / 255;
        LightImage.color = color;
    }

    public void ChangeVolumn(float Vo)
    {
        PlayerPrefs.GetFloat("Volumn", Vo);
        VolumnSlider.minValue = 0f;
        VolumnSlider.maxValue = 1f;
        VolumnSlider.value = Vo;
        PlayerPrefs.SetFloat("Volumn", Vo);
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
    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width,
            resolutions[resolutionNum].height,
            screenMode);
        settingMg.SaveSen();
    }
}
