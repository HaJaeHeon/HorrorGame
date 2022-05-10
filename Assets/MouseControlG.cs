using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControlG : MonoBehaviour
{
    [SerializeField]
    MosterCtrl monsterControl;

    private void Awake()
    {
        monsterControl = GameObject.Find("Voodoo2").GetComponent<MosterCtrl>();
    }


    void Update()
    {
        MouseVisble();
    }

    private void MouseVisble()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "GameScene")
        {
            if (monsterControl.playerDie == false)
                Cursor.visible = false;
            else if (monsterControl.playerDie == true)
                Cursor.visible = true;
        }


    }
}
