using UnityEngine;
using System.Collections;

public class SpookySpider : MonoBehaviour 
{
    // used for moving spider
    public Vector3 forwardDir = Vector3.forward;

    // how many units to move per second
    public float moveSpeed = 20.0f;

    // how much to wobble
    public float wobble = 0.25f;

    // which direction to wobble
    public float wobbleDirection = +1.0f;

    // how long to wobble for
    public float wobbleTime = 1.0f;

    // for internal timer check
    static float elapsedWobbleTime = 0.0f;
	
	// Update is called once per frame
	void Update () 
    {
        float dt = Time.deltaTime;
        
        transform.Translate(forwardDir * moveSpeed * dt);
        transform.Rotate(forwardDir, wobble * wobbleDirection * dt);

        elapsedWobbleTime += dt;
        if (elapsedWobbleTime >= wobbleTime)
        {
            elapsedWobbleTime = 0.0f;
            wobbleDirection *= -1.0f;
        }


	}
}
