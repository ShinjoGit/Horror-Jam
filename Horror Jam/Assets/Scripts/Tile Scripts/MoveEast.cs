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
        if (other.gameObject == player)
            player.GetComponent<ManageTiles>().UpdateEast(transform.parent.transform.position);
    }

}
