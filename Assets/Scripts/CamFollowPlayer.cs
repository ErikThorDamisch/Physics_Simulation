using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    Camera cam;
    public Transform player;
    public Transform player2;
    public GameObject Rock;

    GameObject gameManager;
    RoundScript roundScript;

    void Start ()
    {
        cam = GetComponent<Camera>();
        gameManager = GameObject.Find("GameManager");
        roundScript = gameManager.GetComponent<RoundScript>();
    }
	
	void Update ()
    {
        if (roundScript.whosTurn)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
        else if (!roundScript.whosTurn)
        {
            transform.position = new Vector3(player2.position.x, player2.position.y, -10);
        }
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
