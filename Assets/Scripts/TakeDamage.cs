using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public Text winText;
    public int healthP1;
    public int healthP2;
    RoundScript roundScript;
    GameObject gameManager;
    int damage;

	void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        roundScript = gameManager.GetComponent<RoundScript>();
        healthP1 = 100;
        healthP2 = 100;
        damage = 10;
	}

    private void Update()
    {
        if(healthP1 <= 0)
        {
            winText.text = "Player 2 Wins";
            roundScript.NoneMove = true;
        }
        else if(healthP2 <= 0)
        {
            winText.text = "Player 1 Wins";
            roundScript.NoneMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.name == "Player1" && collision.gameObject.tag == "Rock2")
        {
            Destroy(collision.gameObject);
            healthP1 -= damage;
            print("lol");
            roundScript.NoneMove = false;
        }

        if(this.gameObject.name == "Player2" && collision.gameObject.tag == "Rock1")
        {
            Destroy(collision.gameObject);
            healthP2 -= damage;
            print("lol");
            roundScript.NoneMove = false;
        }
    }
}
