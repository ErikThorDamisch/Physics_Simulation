using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    Camera cam;
    public Transform player;

	void Start ()
    {
        cam = GetComponent<Camera>();
	}
	
	void Update ()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
        float camSize = cam.orthographicSize;
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            camSize -= 1;
            cam.orthographicSize = Mathf.Clamp(camSize, 5, 25); ;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camSize += 1;
            cam.orthographicSize = Mathf.Clamp(camSize, 5, 25); ;
        }
    }
}
