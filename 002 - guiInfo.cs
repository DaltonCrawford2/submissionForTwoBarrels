using UnityEngine;
using System.Collections;

public class guiInfo : MonoBehaviour 
{
	
	public string movementPrefix = "W: Forward  S: Backward  A: Turn Left  D: Turn Right  Left Click: Attack ";
	public string infoPrefix_0 = "A wild Space Invader ATTACKED!";
	public string infoPrefix_1 = "Meteor Hit and Run!";
	public string infoPrefix_2 = "You DON'T touch the BOSS!";
	public int displayCounter;
	
	void Start ()
	{
		//
		guiText.pixelOffset = new Vector2(0, -30);
		
		displayCounter = 50;
				
		if (displayCounter > 0)
		{
			guiText.text = movementPrefix;
			displayCounter -= 1;
		}
		if (displayCounter == 0)
		{
			guiText.text = " ";
		}
			
	}
	
	
	public void UpdateInfoShown(int infoToShow) 
	{
		
		// This will display to the user, info regarding in game interactions.
		
		if (displayCounter == 0)
		{
			guiText.text = " ";
		}
		
		if (infoToShow == 0)
		{
			displayCounter = 10;
			if (displayCounter > 0)
			{
				guiText.text = infoPrefix_0;
				displayCounter -= 1;
			}
		}
		
		if (infoToShow == 1)
		{
			displayCounter = 10;
			if (displayCounter > 1)
			{
				guiText.text = infoPrefix_1;
				displayCounter -= 1;
			}
		}
		
		if (infoToShow == 2)
		{
			displayCounter = 10;
			if (displayCounter > 1)
			{
				guiText.text = infoPrefix_2;
				displayCounter -= 1;
			}
		}
	}
}