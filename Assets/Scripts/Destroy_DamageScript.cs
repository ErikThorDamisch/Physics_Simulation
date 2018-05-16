﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_DamageScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject, 5);
        }
    }
}
