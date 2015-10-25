using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    // singlton
    public static GameObject manager;

    // keep track of game time
    //double timer = 0;
    // keep track of score
    //ulong score = 0;

    void Awake()
    {
        if (manager == null)
        {
            manager = this.gameObject;
            DontDestroyOnLoad(manager);
        }
        else if (manager != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

}
