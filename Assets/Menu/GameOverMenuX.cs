using UnityEngine;
using System.Collections;

public class GameOverMenuX : MenuX
{
	protected override void SetButtons()
	{
		buttons = new string[] {"New Game"};
	}

	protected override void HandleButton (string text)
	{
		switch(text) 
		{
		case "New Game": NewGame(); break;
			
		default: break;
		}
	}

	private void NewGame()
	{
		PlayerPrefs.SetInt("Player1", 0);
		PlayerPrefs.SetInt("Player2", 0);
        PlayerPrefs.SetInt("Player3", 0);
        PlayerPrefs.SetInt("Player4", 0);
		Application.LoadLevel("Main Menu");
		Time.timeScale = 1.0f; // not sure if this is necessary
	}

}
