using UnityEngine;
using System.Collections;
//using UnityEditor;

public class TireRacingGM : MonoBehaviour 
{
    public Material[] playerColors;
    public GameObject Donphan;
    GameObject[] donphans = new GameObject[4];
	// Use this for initialization
    void Start () 
    {
        // creating the players
        for(int i = 0; i < GameManager.numberOfPlayers; i++)
        {
            GameObject donphan = (GameObject)Instantiate(Donphan);
            donphan.GetComponentInChildren<Donphan_Body>().GetComponentInChildren<Renderer>().material = playerColors[i]; // color the player the default will be blue if this fails
            donphan.transform.position = new Vector3(0, 19.5f, 75 + 15 * i); // spaced equally apart
            donphan.GetComponent<Donphan>().moveKeys = GameManager.moveSets[i];
            //player.GetComponent<PlayerX>().setName("Player" + (i + 1));
            donphans[i] = donphan;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
