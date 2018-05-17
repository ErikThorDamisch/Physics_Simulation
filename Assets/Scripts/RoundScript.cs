using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundScript : MonoBehaviour
{
    public bool whosTurn;
    public bool NoneMove;
    ShootScript shootScript;
    ShootScriptPlayer2 shootScriptPlayer2;
    MoveScript moveScript1;
    MoveScript moveScript2;
    GameObject player1;
    GameObject player2;

	void Start ()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        shootScript = player1.GetComponent<ShootScript>();
        shootScriptPlayer2 = player2.GetComponent<ShootScriptPlayer2>();
        moveScript1 = player1.GetComponent<MoveScript>();
        moveScript2 = player2.GetComponent<MoveScript>();
        moveScript2.enabled = false;
        shootScriptPlayer2.enabled = false;
        shootScript.enabled = false;
        moveScript1.enabled = false;
        whosTurn = true;
	}
	
	void Update ()
    {
        if (NoneMove)
        {
            shootScriptPlayer2.enabled = false;
            shootScript.enabled = false;
            moveScript2.enabled = false;
            moveScript1.enabled = false;
        }
        else if(whosTurn)
        {
            shootScriptPlayer2.enabled = false;
            shootScript.enabled = true;
            moveScript2.enabled = false;
            moveScript1.enabled = true;
        }
        else if (!whosTurn)
        {
            shootScriptPlayer2.enabled = true;
            shootScript.enabled = false;
            moveScript2.enabled = true;
            moveScript1.enabled = false;
        }
    }
}
