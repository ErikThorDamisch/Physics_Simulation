using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public GameObject MainMenuButton;
    public Text winText;
    public Text dmgText;
    public Text hp1Text;
    public Text hp2Text;
    public int healthP1;
    public int healthP2;
    RoundScript roundScript;
    GameObject gameManager;
    int damage;
    bool showHit;

	void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        roundScript = gameManager.GetComponent<RoundScript>();
        healthP1 = 100;
        healthP2 = 100;
        damage = 100;
        MainMenuButton.SetActive(false);
	}

    private void Update()
    {
        if(healthP1 < 100)
        {
            hp1Text.text = "Player 1:" + healthP1.ToString();
        }
        else if(healthP2 < 100)
        {
            hp2Text.text = "Player 2:" + healthP2.ToString();
        }

        if(healthP1 <= 0)
        {
            MainMenuButton.SetActive(true);
            winText.text = "Player 2 Wins";
            roundScript.NoneMove = true;
        }
        else if(healthP2 <= 0)
        {
            MainMenuButton.SetActive(true);
            winText.text = "Player 1 Wins";
            roundScript.NoneMove = true;
        }

        if (showHit)
        {
            StartCoroutine(WaitForASecond());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.name == "Player1" && collision.gameObject.tag == "Rock2")
        {
            Destroy(collision.gameObject);
            healthP1 -= damage;
            roundScript.NoneMove = false;
            showHit = true;
        }

        if(this.gameObject.name == "Player2" && collision.gameObject.tag == "Rock1")
        {
            Destroy(collision.gameObject);
            healthP2 -= damage;
            roundScript.NoneMove = false;
            showHit = true;
        }
    }

    IEnumerator WaitForASecond()
    {
        dmgText.text = "HIT! 10 DMG";
        yield return new WaitForSeconds(2f);
        dmgText.text = "";
        showHit = false;
    }
}
