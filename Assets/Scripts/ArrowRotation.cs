using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    Rigidbody2D arrow;

    void Start ()
    {
        arrow = GetComponent<Rigidbody2D>();
	}
	

	void Update ()
    {
        arrow.centerOfMass = new Vector2(0, 0.5f);
    }
}
