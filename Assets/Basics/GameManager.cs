using UnityEngine;
using System.Collections;

public class GameManager
{
	public static float Edge = 60;
	public static float MoveSpeed = 20;
	public static float FreezeTime = 10;
	public static float ObstacleSpeed = 30;
	public static float DownTime = 200;
	public static float newToy = 1000 * Time.deltaTime;
	public static float numberOfPlayers = 4;

	static string[] moveSet1 = {"w", "a", "s", "d", "x"};
	static string[] moveSet2 = {"i", "j", "k", "l", "m"};
	static string[] moveSet3 = {"up", "left", "down", "right", "right shift"};
	static string[] moveSet4 = {"[8]", "[4]", "[2]", "[6]", "[5]"};

	public static string[][] moveSets = {moveSet1, moveSet2, moveSet3, moveSet4};

	private static float buttonHeight = 80;
	private static float mainMenuWidth = 200;
	private static float buttonWidth = 300;
	private static float mainMenuHeight = 100;
	private static float headerHeight = 80, headerWidth = 500;
	private static float textHeight = 25, padding = 10;
	public static float MainMenuWidth { get {return mainMenuWidth;}}
	public static float MainMenuHeight { get {return mainMenuHeight;}}
	public static float PauseMenuHeight { get { return headerHeight + 2 * buttonHeight + 4 * padding; } }
	public static float MenuWidth { get { return headerWidth + 2 * padding; } }
	public static float ButtonHeight { get { return buttonHeight; } }
	public static float ButtonWidth { get { return buttonWidth; } }
	public static float HeaderHeight { get { return headerHeight; } }
	public static float HeaderWidth { get { return headerWidth; } }
	public static float TextHeight { get { return textHeight; } }
	public static float Padding { get { return padding; } }

}
