using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_DamageScript : MonoBehaviour
{
    RoundScript roundScript;
    GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        roundScript = gameManager.GetComponent<RoundScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject, 0.5f);
            roundScript.NoneMove = false;
        }
    }
}
