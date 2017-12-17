using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageBoard : MonoBehaviour 
{

	int[] playerScores = new int[4];
	string[] highScorers = new string[4];
	Color[] playerColors = {Color.blue, Color.green, Color.red, Color.yellow};
	int highScore = 0;
	int numOfhighScorers = 0;
	bool done = false;
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Game Over");
		for(int i = 1; i < 5; i++)
		{
			playerScores[i - 1] = PlayerPrefs.GetInt("Player" + i);
		}
		highScore = Mathf.Max(playerScores);
		findHighScorers();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!done)
		{
			done = true;
			DisplayMessage();
		}

	}

	void findHighScorers()
	{
		for(int i = 1; i < 5; i++)
		{
			if(playerScores[i - 1] == highScore)
			{
				highScorers[numOfhighScorers] = "Player " + i;
				numOfhighScorers++;
			}
		}
	}

	void DisplayMessage()
	{
		if(numOfhighScorers == 1)
		{
			gameObject.GetComponent<GUIText>().text = highScorers[0] + " Wins";
		}
		else if(numOfhighScorers == 2)
		{
			gameObject.GetComponent<GUIText>().text = highScorers[0] + " and " + highScorers[1] + " Wins";
		}
		else if(numOfhighScorers == 3)
		{
			gameObject.GetComponent<GUIText>().text = highScorers[0]+ ", " + highScorers[1] + " and " + highScorers[2] + " Wins";
		}
		else
		{
			gameObject.GetComponent<GUIText>().text = "Draw";
		}
	}
}
