using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperExit : MonoBehaviour
{
    public GameObject paper;

    public void ExitPaper()
    {
        paper.SetActive(false);
    }
}
