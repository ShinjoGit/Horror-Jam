using UnityEngine;
using System.Collections;

public class TileInfo : MonoBehaviour 
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player.GetComponent<ManageTiles>().NSTrigger)
                player.GetComponent<ManageTiles>().NSTrigger = false;
            if (player.GetComponent<ManageTiles>().EWTrigger)
                player.GetComponent<ManageTiles>().EWTrigger = false;
        }
    }
}
