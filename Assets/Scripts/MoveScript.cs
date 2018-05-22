using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float Speed;
    public Animator anim1;
    public Animator anim2;
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
            if (this.gameObject.name == "Player1")
            {
                anim1.SetBool("IsMoving", true);
            }
            else if (this.gameObject.name == "Player2")
            {
                anim2.SetBool("IsMoving", true);
            }

        }
        else if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(horizontal * Speed, 0, 0);
            if (this.gameObject.name == "Player1")
            {
                anim1.SetBool("IsMoving", true);
            }
            else if (this.gameObject.name == "Player2")
            {
                anim2.SetBool("IsMoving", true);
            }
        }
        else
        {
            anim1.SetBool("IsMoving", false);
            anim2.SetBool("IsMoving", false);
        }

        jump = Input.GetButtonDown("Jump");

        if(jump && canJump)
        {
            rb.AddForce(new Vector2(0, 480));
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
