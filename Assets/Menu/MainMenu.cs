using UnityEngine;
using System.Collections;

public class MainMenu : Menu 
{
	protected override void Start()
	{
		base.Start();
		base.columns = 4;
	}
	protected override void SetButtons()
	{
		buttons = new string[] {"Man Bat", "Bey-Blades", "Slice 'n' Dice", "Weazel Balling", " 3-D Hockey", "Power Plant", "Tire Racing", "Streaming Stampede", "Treadmill 2", "Santa","Egg Emergency", "Mine!"};
		//buttons = new string[] {"Bey-Blades", "Tire Racing", "Santa"};
	}
	
	
	protected override void HandleButton (string text) 
	{
		if(text == "Man Bat" || text == "Santa")
		{
			LoadMiniGame(text);
		}
	}
	
	private void LoadMiniGame(string text)
	{
		Application.LoadLevel(text);
		Time.timeScale = 1.0f; // not sure if this is necessary
	}


}
