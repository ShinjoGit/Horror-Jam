using UnityEngine;
using System.Collections;

public class MoveSouth : MonoBehaviour 
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<ManageTiles>().UpdateSouth();
    }

    void OnTriggerExit(Collider other)
    {
        if (player.GetComponent<ManageTiles>().NSTrigger)
            player.GetComponent<ManageTiles>().NSTrigger = false;
    }
}
