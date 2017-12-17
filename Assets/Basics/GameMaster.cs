using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{
	float totalTime = 0; // testing
	int takeTime = 0; // testing
	int numOfObstacles = 0;
	public Material[] toyColors;
	public Material[] playerColors;
	public GameObject Toy;
	public GameObject Player;
	public GameObject Swinub;
	GameObject[] players = new GameObject[4];
	GameObject[] toysInPlay = new GameObject[11];
	float[] makingNewToys = new float[11];
	// Use this for initialization
	void Start () 
	{
		// creating the players
		for(int i = 0; i < GameManager.numberOfPlayers; i++)
		{
			GameObject player = (GameObject)Instantiate(Player);
			player.GetComponent<Renderer>().material = playerColors[i]; // color the player the default will be blue if this fails
			player.GetComponentInChildren<BackPack>().GetComponent<Renderer>().material = playerColors[i]; // color the backpack
			player.transform.position = new Vector3(i * 24 - 36, 10, 45); // spaced equally apart
			player.GetComponent<PlayerX>().moveKeys = GameManager.moveSets[i];
			player.GetComponent<PlayerX>().setName("Player" + (i + 1));
			players[i] = player;
		}
		for(int i = 0; i < makingNewToys.Length; i++) // opening the 'factory'
		{
			makingNewToys[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < 11; i++)
		{
			if(toysInPlay[i] == null)
			{
				float makeToy = Random.Range(1, 10) * Time.deltaTime;
				makingNewToys[i] += makeToy;
				if (makingNewToys[i] > GameManager.newToy)
				{
					makingNewToys[i] = 0;
					int color = Random.Range(0, 5);
					GameObject toy = (GameObject)Instantiate(Toy);
					toy.transform.position = new Vector3(i * 10 - 50, 2.5f, -60);
					toy.GetComponent<Renderer>().material = toyColors[color];
					//Debug.Log(toy.GetComponent<Renderer>().material.name + " created");
					toysInPlay[i] = toy;
				}
			}
		}

		float getTime = gameObject.GetComponent<Clock>().getTime();
		if(numOfObstacles < 1 && getTime <= 59)
		{
			numOfObstacles++;
			SpawnSwinub(0);
		}
		if(numOfObstacles < 2 && getTime <= 40)
		{
			numOfObstacles++;
			SpawnSwinub(-20);
		}
		if(numOfObstacles < 3 && getTime <= 20)
		{
			numOfObstacles++;
			SpawnSwinub(20);
		}
		
	}

	void SpawnSwinub(float positionZ)
	{
		int direction = Random.Range(0, 2);
		if(direction == 0)
		{
			direction = -1;
		}
		GameObject swinub = (GameObject)Instantiate(Swinub);
		if(direction == 1)
		{
			swinub.GetComponent<Obstacle>().obstacleDirection = DeliDelivery.ObstacleDirection.Left;
		}
		else
		{
			swinub.GetComponent<Obstacle>().obstacleDirection = DeliDelivery.ObstacleDirection.Right;
		}
		swinub.transform.position = new Vector3(direction * GameManager.Edge, 2.5f, positionZ);
	}
}
