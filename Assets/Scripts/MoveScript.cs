using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float Speed;
    float horizontal;
    bool jump;
    bool canJump;
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
	}


	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.Translate(-horizontal * Speed, 0, 0);
            //rb.AddForce(new Vector2(-10 * Speed, 0));
            //rb.velocity = new Vector2(horizontal * Speed, 0);
        }
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(horizontal * Speed, 0, 0);
            //rb.AddForce(new Vector2(10 * Speed, 0));
            //rb.velocity = new Vector2(horizontal * Speed, 0);
        }

        jump = Input.GetButtonDown("Jump");

        if(jump && canJump)
        {
            rb.AddForce(new Vector2(0, 500));
            StartCoroutine(WaitForJump());
        }

    }

    IEnumerator WaitForJump()
    {
        canJump = false;
        yield return new WaitForSeconds(1.5f);
        canJump = true;
    }
}
