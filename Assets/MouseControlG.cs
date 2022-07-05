using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlG : MonoBehaviour
{
    [SerializeField]
    MosterCtrl monsterControl;
    public MosterCtrl3 monster3Ctrl;
    [SerializeField]
    GameObject SettingPanel;
    public GameObject YPaperPanel;
    public GameObject GPaperPanel;
    public GameObject BPaperPanel;
    public GameObject EndPaperPanel;
    public GameObject EndingPanel;
    public GameObject guidePanel;


    private void Awake()
    {
        //monsterControl = GameObject.Find("Voodoo2").GetComponent<MosterCtrl>();
        //SettingPanel = GameObject.Find("UICanvas").transform.Find("SettingPanel").
        //    GetComponent<GameObject>();
        Cursor.visible = false;
    }


    void Update()
    {
        //MouseVisble();
        Cursor.lockState = CursorLockMode.Confined;
        MouseVisble();

    }

    private void MouseVisble()
    {

        //if (monsterControl.playerDie == false)
        //    Cursor.visible = false;
        if (monsterControl.playerDie == true)
            Cursor.visible = true;
        else if (monster3Ctrl.playerDie == true)
            Cursor.visible = true;
        else if (guidePanel.activeSelf == true)
            Cursor.visible = true;

        else if (SettingPanel.activeSelf == true)
            Cursor.visible = true;
        //else if (SettingPanel.activeSelf == false)
        //    Cursor.visible = false;

        else if (YPaperPanel.activeSelf == true)
            Cursor.visible = true;
        //else if (YPaperPanel.activeSelf == false)
        //    Cursor.visible = false;

        else if (GPaperPanel.activeSelf == true)
            Cursor.visible = true;
        //else if (GPaperPanel.activeSelf == false)
        //    Cursor.visible = false;

        else if (BPaperPanel.activeSelf == true)
            Cursor.visible = true;
        //else if (BPaperPanel.activeSelf == false)
        //    Cursor.visible = false;

        else if (EndPaperPanel.activeSelf == true)
            Cursor.visible = true;

        else if (EndingPanel.activeSelf == true)
            Cursor.visible = true;



        else
            Cursor.visible = false;





    }
}
