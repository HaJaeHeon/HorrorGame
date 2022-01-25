using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {
	
	public GameObject my_door;
	
	public enum _my_trigger
		{
		trigger_A,
		trigger_B,
		reach,
		pause
		}
	
	public _my_trigger my_trigger = _my_trigger.trigger_A;
	

    void OnTriggerEnter(Collider other) 
		{
       	if (other.tag == "Player")
			{
			door _my_door = (door)my_door.GetComponent("door");
				switch(my_trigger)
					{
					case _my_trigger.trigger_A:
						_my_door.trigger_A = true;
					break;
				
					case _my_trigger.trigger_B:
						_my_door.trigger_B = true;
					break;
				
					case _my_trigger.reach:
						_my_door.reach = true;
					break;
				
					case _my_trigger.pause:
						_my_door.pause = true;
					break;
					}
			}
		}
	
	   void OnTriggerExit(Collider other) 
		{
       	if (other.tag == "Player")
			{
			door _my_door = (door)my_door.GetComponent("door");
				switch(my_trigger)
					{
					case _my_trigger.trigger_A:
						_my_door.trigger_A = false;
					break;
				
					case _my_trigger.trigger_B:
						_my_door.trigger_B = false;
					break;
				
					case _my_trigger.reach:
						_my_door.reach = false;
					break;
				
					case _my_trigger.pause:
						_my_door.pause = false;
					break;
					}
			}
		}

}
