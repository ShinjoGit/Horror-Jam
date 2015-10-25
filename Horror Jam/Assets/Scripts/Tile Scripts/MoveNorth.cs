using UnityEngine;
using System.Collections;

public class MoveNorth : MonoBehaviour 
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter(Collider other)
    {
        //player.GetComponent<ManageTiles>().UpdateNorth();
        if (other.gameObject == player)
            player.GetComponent<ManageTiles>().UpdateNorth(transform.parent.transform.position);

    }


}
