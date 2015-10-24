using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    // singlton
    public static GameObject manager;

    // keep track of game time
    double timer;
    // keep track of score
    ulong score;

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
