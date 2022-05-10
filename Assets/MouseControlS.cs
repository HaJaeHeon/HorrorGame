using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControlS : MonoBehaviour
{
    private void Update()
    {
        MouseVisible();
    }

    private void MouseVisible()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "AnotherStartScene")
        {
            Cursor.visible = true;
        }
        
    }

   
}
