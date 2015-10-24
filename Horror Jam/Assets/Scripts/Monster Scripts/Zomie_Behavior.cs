using UnityEngine;
using System.Collections;

public class Zomie_Behavior : MonoBehaviour {

    public Animator Anim;
    public bool IsAlive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Walk();
	}

    void Walk ()
    {
        Vector3 move = new Vector3(0,0,0.01f);
        transform.position = (transform.position + move);

    }



}
