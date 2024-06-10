using UnityEngine;
using System.Collections;

public class guiStuff : MonoBehaviour 
{
	
	public string healthPrefix = "Health Points Left: ";
	
	
	public void UpdateShipHealth(int healthRemaining) 
	{
		// This will display to the user, the amount of health remaing before their ship no longer responds.
		guiText.text = healthPrefix + healthRemaining.ToString ();
	}
}
