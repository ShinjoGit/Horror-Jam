using UnityEngine;
using System.Collections;

public class GameOver_Manager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void buttonPress(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}
