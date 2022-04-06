using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject UIPanel;
    public GameObject GameNamePanel;

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
        SceneLoader.Instance.LoadScene("GameScene");
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
}
