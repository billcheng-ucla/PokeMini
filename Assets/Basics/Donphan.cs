using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Linq.Expressions;

public class Donphan : MonoBehaviour 
{

    enum Direction{Front, Back, Left, Right};
    public string[] moveKeys = new string[4];
    float speed = 10f;
    int[] flags = new int[3];
    int laps = 0;
    int ammo = 3;
    public WheelCollider wheel;
    public GameObject Tornado;
    float donphanSpeed = 2f;
    Vector3 donphanDirection = new Vector3(-1, 0, 0);
    //public float donphanTurn;
    // Use this for initialization
    void Start () 
    {
        
        //StartCoroutine(DriveTest());
        //wheel.motorTorque = donphanSpeed;
    }

    // Update is called once per frame
    public void Update () 
    {
        transform.Translate(donphanSpeed * Vector3.forward);
        ProcessInput();
    }

    IEnumerator DriveTest() // IEnumerator kinda like void
    {
        print("Start Donphan Testing");
        print("Move Forward");
        yield return new WaitForSeconds(3);
        //wheel.motorTorque = donphanSpeed;

    }

    void ProcessInput()
    {
        float direction = transform.rotation.eulerAngles.y;
        if(Input.GetKeyDown(moveKeys[4]))
        {
            DropTornado();
        }
        if(Math.Abs(direction - 270) < 0.1) // donphan facing left
        {
            if (Input.GetKeyDown(moveKeys[0]))
            {
                transform.Rotate(new Vector3(0, 90f, 0)); 
                donphanDirection = new Vector3(0, 0, 1);
                Debug.Log(transform.eulerAngles);
            }

            if (Input.GetKeyDown(moveKeys[2]))
            {
                transform.Rotate(new Vector3(0, -90f, 0)); 
                donphanDirection = new Vector3(0, 0, -1);
                Debug.Log(transform.eulerAngles);
            }
        }

        else if(Math.Abs(direction - 180) < 0.1) // donphan facing left
        {
            if (Input.GetKeyDown(moveKeys[1]))
            {
                transform.Rotate(new Vector3(0, 90f, 0)); // 90 % 4 I dunno y this is necessary but when I press space this executes 4x
                Debug.Log(transform.eulerAngles);
            }

            if (Input.GetKeyDown(moveKeys[3]))
            {
                transform.Rotate(new Vector3(0, -90f, 0)); // 90 % 4 I dunno y this is necessary but when I press space this executes 4x
                Debug.Log(transform.eulerAngles);
            }
        }

        else if(Math.Abs(direction - 90) < 0.1) // donphan facing left
        {
            if (Input.GetKeyDown(moveKeys[0]))
            {
                transform.Rotate(new Vector3(0, -90f, 0)); // 90 % 4 I dunno y this is necessary but when I press space this executes 4x
                Debug.Log(transform.eulerAngles);
            }

            if (Input.GetKeyDown(moveKeys[2]))
            {
                transform.Rotate(new Vector3(0, 90f, 0)); // 90 % 4 I dunno y this is necessary but when I press space this executes 4x
                Debug.Log(transform.eulerAngles);
            }
        }

        else if(Math.Abs(direction) < 0.1) // donphan facing left
        {
            if (Input.GetKeyDown(moveKeys[1]))
            {
                transform.Rotate(new Vector3(0, -90f, 0)); // 90 % 4 I dunno y this is necessary but when I press space this executes 4x
                Debug.Log(transform.eulerAngles);
            }

            if (Input.GetKeyDown(moveKeys[3]))
            {
                transform.Rotate(new Vector3(0, 90f, 0)); // 90 % 4 I dunno y this is necessary but when I press space this executes 4x
                Debug.Log(transform.eulerAngles);
            }
        }
    }

    void DropTornado()
    {
        Debug.Log("Dropping Tornado");
        if (ammo > 0)
        {
            ammo--;
            GameObject tornado = (GameObject)Instantiate(Tornado);
            tornado.GetComponentInChildren<Cone>().GetComponent<Renderer>().material = GetComponentInChildren<Donphan_Body>().GetComponentInChildren<Renderer>().material;
            tornado.GetComponentInChildren<Cylinder>().GetComponent<Renderer>().material = GetComponentInChildren<Donphan_Body>().GetComponentInChildren<Renderer>().material;
            tornado.transform.position = transform.position + Vector3.back;
        }
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