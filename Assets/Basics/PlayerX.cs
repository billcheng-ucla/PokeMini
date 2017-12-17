using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerX : MonoBehaviour 
{
	public string[] moveKeys = new string[4];
	string name = "";
	bool fallen = false;
	int downTime = 0;
	List<string> heldToys = new List<string>();
	BackPack myFirstBackpack;
	int score = 0;

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt(name, score);
		myFirstBackpack = GetComponentInChildren<BackPack>();
	}
	
	// Update is called once per frame
	// void OnGUI () 
	void Update()
	{

		if (heldToys.Count > 0)
		{
			myFirstBackpack.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			myFirstBackpack.GetComponent<Renderer>().enabled = false;
		}
		if(fallen)
		{
			//Debug.Log(name + " has fallen and he can't get up " + downTime);
			GetUp();
		}
		else
		{
			transform.rotation = Quaternion.identity;
			ProcessInput();
		}

		if(transform.position.z >= GameManager.Edge)
		{
			UpdateScore();
		}
		CheckEdge();
	
	}

	void UpdateScore()
	{
		for(int i = 0; i < heldToys.Count; i++)
		{
			if((string)heldToys[i] == "white")
			{
				score += 20;
			}
			
			else if((string)heldToys[i] == "green")
			{
				score += 50;
			}
			
			else if((string)heldToys[i] == "blue")
			{
				score += 100;
			}
			
			else if((string)heldToys[i] == "red")
			{
				score += 250;
			}
			
			else if((string)heldToys[i] == "black")
			{
				score += 350;
			}
			
		}
		PlayerPrefs.SetInt(name, score);
		
		DropEverything();
		
		Debug.Log(score);
	}

	void GetUp()
	{
		if(downTime < GameManager.DownTime)
		{
			downTime ++;
		}
		else
		{
			fallen = false;
			downTime = 0;
			transform.rotation = Quaternion.identity;
			Debug.Log("Ok I have gotten up");
		}
	}

	void ProcessInput()
	{
		float movement = GameManager.MoveSpeed * Time.deltaTime;
		if (Input.GetKey(moveKeys[0]))
		{
			transform.Translate(0f, 0f, movement);
		}
		else if (Input.GetKey(moveKeys[1]))
		{
			transform.Translate(-1 * movement, 0f, 0f);
		}
		else if (Input.GetKey(moveKeys[2]))
		{
			transform.Translate(0f, 0f, -1 * movement);
			
		}
		else if (Input.GetKey(moveKeys[3]))
		{
			transform.Translate(movement, 0f, 0f);
		}
		else if (Input.GetKey(KeyCode.X))
		{
			Application.LoadLevel("Game Over");
		}
		/*
		else if (Input.GetKey(KeyCode.M)) // testing
		{
			heldToys.Add("Fake");
		}
		*/
	}

	void CheckEdge()
	{
		if (Mathf.Abs(transform.position.x) > GameManager.Edge) // Check LR edges
		{
			float bias = transform.position.x / Mathf.Abs(transform.position.x); // set position to +- 1 depending on LR edge
			transform.position = new Vector3(bias * GameManager.Edge, transform.position.y, transform.position.z); // set position to edge
		}
		if (Mathf.Abs(transform.position.z) > GameManager.Edge) // Check Front/Back edges
		{
			float bias = transform.position.z / Mathf.Abs(transform.position.z); // set position to +- 1 depending on Front/Back edge
			transform.position = new Vector3(transform.position.x, transform.position.y, bias * GameManager.Edge); // set position to edge
		}
	}

	void DropEverything()
	{
		heldToys.Clear();
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.collider.tag == "Swinub")
		{
			fallen = true;
			DropEverything();
		}
		if(collisionInfo.collider.tag == "Toy")
		{
			if (heldToys.Count < 5)
			{
				//Debug.Log(collisionInfo.gameObject.GetComponent<Renderer>().material.name);
				string toyColor = GetToyColor(collisionInfo.gameObject.GetComponent<Renderer>().material);
				//Debug.Log (toyColor); // testing
				heldToys.Add(toyColor);
				Destroy(collisionInfo.gameObject);
			}
		}
	}

	public void setName(string name)
	{
		this.name = name;
	}

	string GetToyColor(Material material)
	{
		if(material.name == "White Toy (Instance)")
		{
			return "white";
		}
		else if(material.name == "Blue Toy (Instance)")
		{
			return "blue";
		}
		else if(material.name == "Black Toy (Instance)")
		{
			return "black";
		}
		else if(material.name == "Red Toy (Instance)")
		{
			return "red";
		}
		else if(material.name == "Green Toy (Instance)")
		{
			return "green";
		}
		else
		{
			Debug.Log("Error: This is not a Toy");
			return "ERROR";
		}
	}
}
