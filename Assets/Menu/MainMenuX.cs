using UnityEngine;
using System.Collections;

public class MainMenuX : MenuX 
{
	protected override void SetButtons()
	{
		//buttons = new string[] {"Man Bat", "Bey-Blades", "Slice 'n' Dice", "Weazel Balling", " 3-D Hockey", "Power Plant", "Tire Racing", "Streaming Stampede", "Treadmill 2", "Santa","Egg Emergency", "Mine!"};
		buttons = new string[] {"Bey-Blades", "Tire Racing", "Santa"};
	}


	protected override void HandleButton (string text) 
	{
		switch(text) 
		{
		case "Santa": Santa(); break;
		
		default: break;
		}
	}

	private void Santa()
	{
		Application.LoadLevel("Santa");
		Time.timeScale = 1.0f; // not sure if this is necessary
	}
}
