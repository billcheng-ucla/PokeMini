using UnityEngine;
using System.Collections;

public class MenuX : MonoBehaviour 
{
	
	public GUISkin mySkin;
	public Texture2D header;
	
	protected string[] buttons;
	
	protected virtual void Start () 
	{
		SetButtons();
	}
	
	protected virtual void OnGUI() 
	{
		DrawMenu();
	}
	
	protected virtual void DrawMenu() 
	{
		//default implementation for a menu consisting of a vertical list of buttons
		GUI.skin = mySkin;
		float menuHeight = GetMenuHeight();
		
		float groupLeft = Screen.width / 2 - GameManager.MenuWidth / 2;
		float groupTop = Screen.height / 2 - menuHeight / 2;
		GUI.BeginGroup(new Rect(groupLeft, groupTop, GameManager.MenuWidth, menuHeight));
		
		//background box
		GUI.Box(new Rect(0, 0, GameManager.MenuWidth, menuHeight), "");
		//header image
		GUI.DrawTexture(new Rect(GameManager.Padding, GameManager.Padding, GameManager.HeaderWidth, GameManager.HeaderHeight), header);
		
		//menu buttons
		if(buttons != null) 
		{
			float leftPos = GameManager.MenuWidth / 2 - GameManager.ButtonWidth / 2;
			float topPos = 6 * GameManager.Padding + header.height;
			for(int i = 0; i < buttons.Length; i++) 
			{   if(i > 0) 
				{
					topPos += GameManager.ButtonHeight + GameManager.Padding;
				}
				if(GUI.Button(new Rect(leftPos, topPos, GameManager.ButtonWidth, GameManager.ButtonHeight), buttons[i])) 
				{
					HandleButton(buttons[i]);
				}
			}
		}
		
		GUI.EndGroup();
	}
	
	protected virtual void SetButtons() 
	{
		//a child class needs to set this for buttons to appear
	}
	
	protected virtual void HandleButton(string text) 
	{
		//a child class needs to set this to handle button clicks
	}
	
	protected virtual float GetMenuHeight() 
	{
		float buttonHeight = 0;
		if(buttons != null) buttonHeight = buttons.Length * GameManager.ButtonHeight;
		float paddingHeight = 2 * GameManager.Padding;
		if(buttons != null) paddingHeight += buttons.Length * GameManager.Padding;
		return GameManager.HeaderHeight + buttonHeight + paddingHeight;
	}
	
	protected void ExitGame() 
	{
		Application.Quit();
	}
}
