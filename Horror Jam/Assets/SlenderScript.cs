using UnityEngine;
using System.Collections;

public class SlenderScript : MonoBehaviour
{

    public bool visible;
    public float disappearTimer;
    private Vector3 TargetPosition;

    void Start()
    {

    }
    void Update()
    {

        TargetPosition = GameObject.Find("Player").transform.position;

        TargetPosition.y = 0;
        transform.LookAt(TargetPosition);


        Debug.Log(GetComponent<MeshRenderer>());
        if (GetComponent<MeshRenderer>().isVisible == true)
        {
            visible = true;

            disappearTimer -= Time.deltaTime;
            if (disappearTimer <= 0.0f)
            {
                Vector3 rand = new Vector3(Random.value, 10, Random.value);
                transform.position += rand;
            }
        }
        else
        {
            visible = false;
        }

    }






}
