using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
        string playerName = gameObject.name.Substring(0, 7);
        Debug.Log(playerName);
        gameObject.GetComponent<GUIText>().text = PlayerPrefs.GetInt(playerName).ToString();
        Debug.Log(PlayerPrefs.GetInt(playerName).ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
