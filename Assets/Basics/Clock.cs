using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	float seconds = 60;
	//float seconds = 10;// testing
	
	// Update is called once per frame
	void Update () 
	{
		if (seconds > 0)
		{
			seconds -= Time.deltaTime;
		}
		else
		{
			Application.LoadLevel("Game Over");
		}

		// Display the time
        if(int.Parse(seconds.ToString("f0")) < 10)
		{
			GameObject.Find("Clock").GetComponent<GUIText>().text = "0" + seconds.ToString("f0");
		}
		else
		{
			GameObject.Find("Clock").GetComponent<GUIText>().text = seconds.ToString("f0");
		}
	}

	public float getTime()
	{
		return seconds;
	}
}
