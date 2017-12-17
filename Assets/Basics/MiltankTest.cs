using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;

public class MiltankTest : MonoBehaviour 
{
	float speed = 10f;
	int[] flags = new int[3];
    int laps = 0;
	// Use this for initialization
	void Start () 
	{
        GameObject.Find("Score").GetComponentInChildren<Text>().text = "Hello World";		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(speed * Input.GetAxis("Horizontal"), 0, speed * Input.GetAxis("Vertical"));
	}

	void OnTriggerEnter (Collider checkpoint)
	{
		if (checkpoint.name == "CheckPoint 1") 
		{
            Debug.Log("First Checkpoint Hit");
            flags[0] = 1;
		}

        else if (checkpoint.name == "CheckPoint 2")
        {
            Debug.Log("Second Checkpoint Hit");
            flags[1] = 1;
        }

        else if(checkpoint.name == "CheckPoint 3")
        {
            Debug.Log("Third Checkpoint Hit");
            flags[2] = 1;
        }

        else if(checkpoint.name == "Finish Line")
        {
            bool allcheckpoints = true;
            for(int i = 0; i < 3; i++)
            {
                if(flags[i] == 0)
                {
                    allcheckpoints = false;
                }
            }
            if(allcheckpoints)
            {
                Debug.Log("Lap Finish");
                Array.Clear(flags, 0, 3);
                laps++;
                UpdateLaps();
            }
            else
            {
                Debug.Log("You Cheated! Shame on you!");
            }
        }

      
	}

    void UpdateLaps()
    {
        string message = "Player 1 Laps: " + laps;
        GameObject.Find("Score").GetComponentInChildren<Text>().text = message;
    }

}
