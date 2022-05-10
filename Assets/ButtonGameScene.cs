using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameScene : MonoBehaviour
{
    public void RestartButton()
    {
        SceneLoader.LoadScene("GameScene");
    }

    public void MainMenuButton()
    {
        SceneLoader.LoadScene("AnotherStartScene");
    }
}
