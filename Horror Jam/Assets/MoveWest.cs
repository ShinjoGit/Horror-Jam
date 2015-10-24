using UnityEngine;
using System.Collections;

public class MoveWest : MonoBehaviour 
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<ManageTiles>().UpdateWest();
    }

    void OnTriggerExit(Collider other)
    {
        if (player.GetComponent<ManageTiles>().EWTrigger)
            player.GetComponent<ManageTiles>().EWTrigger = false;
    }
}
