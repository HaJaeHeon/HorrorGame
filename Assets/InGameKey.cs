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

    public bool check = true;
    private void Awake()
    {
        SettingPanel = GameObject.Find("UICanvas")
            .transform.GetChild(1).gameObject;
        GuideUI = GameObject.Find("UICanvas")
            .transform.GetChild(2).gameObject;
        InventoryUI = GameObject.Find("UICanvas")
            .transform.GetChild(3).gameObject;
    }
    void Start()
    {
        MouseSenSlider = GameObject.Find("UICanvas").transform.Find("SettingPanel")
                .transform.Find("SensitiveSlider").GetComponent<Slider>();

        settingMg = GameObject.Find("SettingsMgr").GetComponent<SettingsManager>();

        //settingMg.LoadSen();
        MouseSenSlider.minValue = 0f;
        MouseSenSlider.maxValue = 4f;
        MouseSenSlider.value = settingMg.MouseSensitivity;
    }

    void Update()
    {
        PressEsc();
        PressTab();
        //settingMg.ChangeMouseSen(settingMg.MouseSensitivity);
        MouseSenSlider.onValueChanged.AddListener(ChangeMouseSen);
    }


    void PressEsc()
    {
        
        if (Input.GetKey(KeyCode.Escape) && check)
        {
            if (SettingPanel.activeSelf == false)
            {
                check = false;

                SettingPanel.SetActive(true);
                Time.timeScale = 0.01f;
                StartCoroutine(WaitForUI100());
            }
            else if (SettingPanel.activeSelf == true)
            {
                SettingPanel.SetActive(false);
                Time.timeScale = 1f;
                check = false;
                StartCoroutine(WaitForUI());

            }
        }
    }

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
            if (InventoryUI.transform.position.x < 0)
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

    IEnumerator WaitForUI()
    {
        yield return new WaitForSeconds(0.5f);
        check = true;
    }
    IEnumerator WaitForUI100()
    {
        yield return new WaitForSeconds(0.005f);
        check = true;
    }

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
}
