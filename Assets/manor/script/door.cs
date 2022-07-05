using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	
	public Transform door_obj;
	public Transform handle_obj;
	public Transform pivot_A;
	public Transform pivot_B;
	public bool trigger_A;
	public bool trigger_B;
	public bool reach;
	public bool pause;

	[SerializeField]
	private DoorSound dSound;

    public enum door_state
		{
		close,
		opening_A,
		pause_opening_A,
		end_open_A,
		closing_A,
		pause_closing_A,
		opening_B,
		pause_opening_B,
		end_open_B,
		closing_B,
		pause_closing_B
		}
	public door_state door_actual_state = door_state.close;

    private void Start()
    {
		dSound = gameObject.GetComponent<DoorSound>();
    }

    // Update is called once per frame
    void Update () {
		
		switch(door_actual_state)
			{
			case door_state.close:
				if (Input.GetKeyDown(KeyCode.F))
					Open();
			break;
				
			case door_state.opening_A:
					pivot_A.Rotate(	0,
									-90 * Time.deltaTime, 
									0,
									Space.Self);
			if (pivot_A.transform.localEulerAngles.y <= (270) )
					{
					pivot_A.transform.localEulerAngles = new Vector3(0,270,0);
					End_open();
					}
			break;
			
			case door_state.opening_B:
					pivot_B.Rotate(	0,
									90 * Time.deltaTime, 
									0,
									Space.Self);
					if (pivot_B.transform.localEulerAngles.y >= 90)
						{
						pivot_B.transform.localEulerAngles = new Vector3(0,90,0);
						End_open();
						}
			break;
			
			case door_state.end_open_A:
				if (Input.GetKeyDown(KeyCode.F))
					Close();
			break;
			
			case door_state.end_open_B:
				if (Input.GetKeyDown(KeyCode.F))
					Close();
			break;
			
			case door_state.closing_A:
				if (!pause)
					{
						pivot_A.Rotate(	0,
										90 * Time.deltaTime, 
										0,
										Space.Self);
						if ( (pivot_A.transform.localEulerAngles.y >= 358) && (pivot_A.transform.localEulerAngles.y <= 360) )
							{
							pivot_A.transform.localEulerAngles = new Vector3(0,0,0);
							End_close();
							}
					}
				else
					door_actual_state = door_state.pause_closing_A;
			break;
			
			case door_state.pause_closing_A:
				if (Input.GetKeyDown(KeyCode.F) && (!pause) )
					door_actual_state = door_state.closing_A;
			break;
			
			case door_state.closing_B:
				if (!pause)
					{
						pivot_B.Rotate(	0,
										-90 * Time.deltaTime, 
										0,
										Space.Self);
						if ( (pivot_B.transform.localEulerAngles.y >= 358) && (pivot_B.transform.localEulerAngles.y <= 360) )
							{
							pivot_B.transform.localEulerAngles = new Vector3(0,0,0);
							End_close();
							}
					}
				else
					door_actual_state = door_state.pause_closing_B;
			break;
			
			case door_state.pause_closing_B:
				if (Input.GetKeyDown(KeyCode.F) && (!pause) )
					door_actual_state = door_state.closing_B;
			break;
			}
	}

	
	void Open()
		{
		//dSound.DoorOpeningSound();
		if (reach)
			{
			Unlink_door();
			dSound.DoorOpeningSound();
			//Debug.Log("11");
			if (trigger_A)
				{
				Link_door_to_pivot(pivot_A);
				door_actual_state = door_state.opening_A;
				}
			else if (trigger_B)
				{
				Link_door_to_pivot(pivot_B);
				door_actual_state = door_state.opening_B;
				}

			}
		}
	
	void Close()
		{
		//dSound.DoorClosingSound();
		if (reach)
			{
			dSound.DoorClosingSound();
			//Debug.Log("22");
			if ( (door_actual_state == door_state.end_open_A) && (!trigger_B) )
				{
				door_actual_state = door_state.closing_A;
				}
			else if ( (door_actual_state == door_state.end_open_B) && (!trigger_A) )
				{
				door_actual_state = door_state.closing_B;
				}
			}
		}
	
	void Unlink_door()
		{
		door_obj.parent = this.gameObject.transform;
		}
	
	void Link_door_to_pivot(Transform target)
		{
		door_obj.parent = target;
		}

	void End_open()
		{
		pause = false;
		switch(door_actual_state)
			{
			case door_state.opening_A:
				door_actual_state = door_state.end_open_A;
			break;
			
			case door_state.opening_B:
				door_actual_state = door_state.end_open_B;
			break;
			}
		}
	
	void End_close()
		{
		door_actual_state = door_state.close;
		Unlink_door();
		}
}
