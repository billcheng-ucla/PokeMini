using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public GUISkin mySkin;
	public Texture2D header;
	protected string[] buttons;
	protected int columns;
	// Use this for initialization
	protected virtual void Start () 
	{
		SetButtons();
	
	}
	
	// Update is called once per frame
	protected virtual void OnGUI () 
	{
		DrawMenu();
	
	}

	protected virtual void DrawMenu() {
		//default implementation for a menu 
		GUI.skin = mySkin;
		float menuHeight = GetMenuHeight();
		float menuWidth = GetMenuWidth();
		float groupLeft = Screen.width / 2 - GameManager.MenuWidth / 2;
		float groupTop = Screen.height / 2 - menuHeight / 2;
		GUI.BeginGroup(new Rect(groupLeft, groupTop, menuWidth, menuHeight));
		
		//background box
		GUI.Box(new Rect(0, 0, menuWidth, menuHeight), "");
		//header image
		float textureLeft = menuWidth / 2 - header.width / 2;
		GUI.DrawTexture(new Rect(textureLeft, GameManager.Padding, header.width, header.height), header);
		
		//menu buttons
		if(buttons != null) 
		{
			float leftPos = 2 * GameManager.Padding;
			float topPos = 2 * GameManager.Padding + header.height;
			for(int i = 0; i < buttons.Length; i++) 
			{   if(i > 0) 
				{
					if(i % columns != 0)
					{
						leftPos += GameManager.ButtonWidth + GameManager.Padding;
					}
					else
					{
						topPos += GameManager.ButtonHeight + GameManager.Padding;
						leftPos = 2 * GameManager.Padding;
					}
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
		if(buttons != null) 
		{
			buttonHeight = GameManager.ButtonHeight * ((buttons.Length - 1) / columns + 1);
		}
		float paddingHeight = 2 * GameManager.Padding;
		if(buttons != null) 
		{
			paddingHeight += ((buttons.Length - 1) / columns + 1) * GameManager.Padding;
		}
		return header.height + buttonHeight + paddingHeight;
	}

	protected virtual float GetMenuWidth()
	{
		float buttonWidth = 0;
		if(buttons != null)
		{
			buttonWidth = columns * GameManager.ButtonWidth;
		}
		float paddingWidth = 2 * GameManager.Padding;
		if(buttons != null)
		{
			paddingWidth += columns * GameManager.Padding;
		}
		float totalButtonWidth = buttonWidth + paddingWidth;
		if(totalButtonWidth < header.width)
		{
			Debug.Log("Header " + header.width);
			return header.width;
		}
		else
		{
			Debug.Log("Buttons " + totalButtonWidth);
			return totalButtonWidth;
		}
	}

	protected void ExitGame() 
	{
		Application.Quit();
	}
}
