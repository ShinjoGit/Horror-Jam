using UnityEngine;
using System.Collections;

public class SlenderScript : MonoBehaviour
{

    public GameObject SlenderObj;
    public Collider SlenderCollider;
    private Camera cam;
    private Plane[] planes;
    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        SlenderCollider = gameObject.GetComponent<CapsuleCollider>();
        SlenderObj = this.gameObject;
    }
    void Update()
    {
        if (GeometryUtility.TestPlanesAABB(planes, SlenderCollider.bounds))
        {
            Debug.Log(SlenderObj.name + " has been detected!");
        }
        else
        {
            Debug.Log("Nothing has been detected");
        }
    }
}
