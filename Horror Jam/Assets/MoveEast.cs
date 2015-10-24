using UnityEngine;
using System.Collections;

public class MoveEast : MonoBehaviour 
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<ManageTiles>().UpdateEast();
    }

    void OnTriggerExit(Collider other)
    {
        if (player.GetComponent<ManageTiles>().EWTrigger)
            player.GetComponent<ManageTiles>().EWTrigger = false;
    }
}
