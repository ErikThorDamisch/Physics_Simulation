using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRaycast : MonoBehaviour
{
    public Transform Origin;
    Vector3 direction;
    RaycastHit hit;

	void Start ()
    {
        direction = new Vector3(0, 0, 1);
	}
	
	void Update ()
    {
	    if(Physics.Raycast(Origin.transform.position, transform.TransformDirection(direction), out hit, 50))
        {
            Debug.DrawRay(Origin.transform.position, transform.TransformDirection(direction) * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(Origin.transform.position, transform.TransformDirection(direction) * 50, Color.green);
        }
	}
}
