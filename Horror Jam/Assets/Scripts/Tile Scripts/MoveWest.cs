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
        if (other.gameObject == player)
            player.GetComponent<ManageTiles>().UpdateWest(transform.parent.transform.position);
    }

}
