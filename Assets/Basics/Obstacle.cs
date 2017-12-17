using UnityEngine;
using System.Collections;
using DeliDelivery;
public class Obstacle : MonoBehaviour {
	public ObstacleDirection obstacleDirection;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		int direction;
		if (obstacleDirection == ObstacleDirection.Left)
		{
			direction = -1;
		}
		else
		{
			direction = 1;
		}
		transform.Translate(GameManager.ObstacleSpeed * direction * Time.deltaTime, 0f, 0f);
		EdgeCheck();
	}

	void EdgeCheck()
	{
		if(Mathf.Abs(transform.position.x) >= GameManager.Edge)
		{
			float newPositionx = transform.position.x / Mathf.Abs(transform.position.x) * GameManager.Edge;
			transform.position = new Vector3(newPositionx, transform.position.y, transform.position.z);
			SwitchDirection();
		}
	}

	void SwitchDirection()
	{
		if (obstacleDirection == ObstacleDirection.Left)
		{
			obstacleDirection = ObstacleDirection.Right;
		}
		else
		{
			obstacleDirection = ObstacleDirection.Left;
		}
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		
	}
}
