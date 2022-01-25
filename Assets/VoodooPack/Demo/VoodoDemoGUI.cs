using UnityEngine;
using System.Collections;

public class VoodoDemoGUI: MonoBehaviour
{

	public GameObject[] Prefabs;

	private int currentNomber;
	private GameObject currentInstance;
	private GUIStyle guiStyleHeader = new GUIStyle();
    float dpiScale;
    Animator anim;

	void Start () {
        if (Screen.dpi < 1) dpiScale = 1;
        if (Screen.dpi < 200) dpiScale = 1;
        else dpiScale = Screen.dpi / 200f;
        guiStyleHeader.fontSize = (int)(15f * dpiScale);
		guiStyleHeader.normal.textColor = new Color(0.15f,0.15f,0.15f);
		currentInstance = Instantiate(Prefabs[currentNomber], transform.position, transform.rotation) as GameObject;
        anim = currentInstance.GetComponent<Animator>();
        
	}
   
	private void OnGUI()
	{
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale, 135 * dpiScale, 37 * dpiScale), "PREVIOUS"))
        {
			ChangeCurrent(-1);
		}
        if (GUI.Button(new Rect(160 * dpiScale, 15 * dpiScale, 135 * dpiScale, 37 * dpiScale), "NEXT"))
		{
			ChangeCurrent(+1);
		}

        if (currentNomber == 5) return;
        
        int countButtons = 0 ;

        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Attack1"))
        {
            anim.SetBool("Attack1", true);
        }

        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Attack2"))
        {
            anim.SetBool("Attack2", true); 
        }
        /////////////////////////////////////////////////////////////////////
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Attack3"))
        {
            anim.SetBool("Attack3", true); 
        }
        ///////////////////////////////////////////////////////////////////
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Attack4"))
        {
            anim.SetBool("Attack4", true);
        }

        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Jump"))
        {
                anim.SetBool("Jump", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Jump2"))
        {
            anim.SetBool("Jump2", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Walk_forward"))
        {
            anim.SetBool("Walk_forward", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Walk_back"))
        {
            anim.SetBool("Walk_back", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Walk_left"))
        {
            anim.SetBool("Walk_left", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Walk_right"))
        {
            anim.SetBool("Walk_right", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Jump_attack"))
        {
            anim.SetBool("Jump_attack", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Melee_attack_kick"))
        {
            anim.SetBool("Melee_attack_kick", true);
        }
        
        countButtons = 0;

        /////////////////////////////////////////вторая колонка*********************
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Hit_from_back"))
        {
            anim.SetBool("Hit_from_back", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Hit_from_front"))
        {
            anim.SetBool("Hit_from_front", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Hit_from_left"))
        {
            anim.SetBool("Hit_from_left", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Hit_from_right"))
        {
            anim.SetBool("Hit_from_right", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Death_backward"))
        {
            anim.SetBool("Death_backward", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Death_forward"))
        {
            anim.SetBool("Death_forward", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Death_left"))
        {
            anim.SetBool("Death_left", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Death_right"))
        {
            anim.SetBool("Death_right", true);
        }
        if (GUI.Button(new Rect(10 * dpiScale + 150, 15 * dpiScale + 15 + 30 * ++countButtons, 135 * dpiScale, 22 * dpiScale), "Run_forward"))
        {
            anim.SetBool("Run_forward", true);
        }


        ///////////////////////////////////////////////////*************************
    }

   
	
	void ChangeCurrent(int delta) {
		currentNomber+=delta;
		if (currentNomber> Prefabs.Length - 1)
			currentNomber = 0;
		else if (currentNomber < 0)
			currentNomber = Prefabs.Length - 1;
		if(currentInstance!=null) Destroy(currentInstance);
		currentInstance = Instantiate(Prefabs[currentNomber], transform.position, transform.rotation) as GameObject;
        anim = currentInstance.GetComponent<Animator>();
    }
}
