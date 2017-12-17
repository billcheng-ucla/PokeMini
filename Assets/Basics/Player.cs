using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	/*
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.rotation = Quaternion.identity;
		bool sideEdge = sideEdgeCheck();
		bool frontEdge = frontEdgeCheck();
		if(!sideEdge)
		{
			transform.Translate(Input.GetAxis("Horizontal") * GameManager.MoveSpeed * Time.deltaTime, 0f, 0f);
		}
		if(!frontEdge)
		{
			transform.Translate(0f, 0f, Input.GetAxis("Vertical") * GameManager.MoveSpeed * Time.deltaTime);
		}
		//transform.Translate(Input.GetAxis("Horizontal") *GameManager.MoveSpeed * Time.deltaTime, 0f, Input.GetAxis("Vertical")* GameManager.MoveSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.X))
		{
			print("Game is Over");
			Application.LoadLevel("Game Over");
		}
	}

	bool sideEdgeCheck()
	{
		float expectedMove = Input.GetAxis("Horizontal") * GameManager.MoveSpeed * Time.deltaTime;
		float expectedLocation = expectedMove + transform.position.x;
		if(Mathf.Abs(expectedLocation) > GameManager.Edge)
		{
			return true;
		}
		return false;
	}

	bool frontEdgeCheck()
	{
		float expectedMove = Input.GetAxis("Vertical") * GameManager.MoveSpeed * Time.deltaTime;
		float expectedLocation = expectedMove + transform.position.z;

		if(Mathf.Abs(expectedLocation) > GameManager.Edge)
		{
			return true;
		}

		return false;
	}
	*/
	void OnCollisionEnter(Collision collisionInfo)
	{
		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		if(collisionInfo.collider.tag == "Swinub")
		{
			Debug.Log("I hit a Swinub");
		}
		
	}



}
