using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRockCam : MonoBehaviour
{
    Camera cam;
	void Start ()
    {
        cam = GetComponent<Camera>();
	}
	
	void Update ()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -100);
	}
}

