using UnityEngine;
using System.Collections;

public class FogFollow : MonoBehaviour 
{
    // follow the position of player
    public GameObject player;

	void Awake () 
    {
	    if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}
	
	void Update () 
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 100.0f, player.transform.position.z);
	}
}
