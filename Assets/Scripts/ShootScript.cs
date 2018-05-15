using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Rigidbody2D Arrow;
    public Transform ShootDirection;
    public Transform Player;
    Rigidbody2D rb;
    Transform ArrowOrigin;
    int speed = 10;
    float rotation;
    float adaptiveRotation;
    bool hasTurned;
    float flatRotation;
    float xForce;
    float yForce;
    float timeLeft;
    float firePower;

    void Start ()
    {
        ArrowOrigin = GameObject.Find("ArrowOrigin").transform;
        hasTurned = true;
        timeLeft = 2;
    }

    void Update ()
    {
        flatRotation = ShootDirection.rotation.eulerAngles.z;
       //if (Input.GetButtonDown("FirePower"))
       //{
       //    ShootForce();
       //    Rigidbody2D ArrowClone = (Rigidbody2D)Instantiate(Arrow, ArrowOrigin.position, Quaternion.Euler(0, 0, 27));
       //    ArrowClone.AddForce(new Vector2(xForce * firePower, yForce * firePower));
       //}
        if (Input.GetButtonDown("FirePower"))
        {
        }
        if (Input.GetButtonUp("FirePower") && timeLeft > 0)
        {
            firePower = ((2 - timeLeft) * 100) / 2;
            ShootForce();
            Rigidbody2D ArrowClone = (Rigidbody2D)Instantiate(Arrow, ArrowOrigin.position, Quaternion.Euler(0, 0, 27));
            ArrowClone.AddForce(new Vector2(xForce * firePower, yForce * firePower));
        }

        RotateShootDirection();
    }

    void FireArrow()
    {
       
        //Rigidbody2D rb = ArrowClone.GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(500, 0) * 10);
    }

    void RotateShootDirection()
    {
        if (Player.rotation.y == -1 && hasTurned)
        {
            adaptiveRotation = 90 + (90 - rotation);
            hasTurned = false;
        }
        else if (Player.rotation.y == -1 && Input.GetButton("FireDirectionUp") && adaptiveRotation >= 100)
        {
            adaptiveRotation -= 1;
            ShootDirection.rotation = Quaternion.Euler(0, 0, adaptiveRotation);
        }
        else if ((Player.rotation.y == -1 && Input.GetButton("FireDirectionDown") && adaptiveRotation <= 180))
        {
            adaptiveRotation += 1;
            ShootDirection.rotation = Quaternion.Euler(0, 0, adaptiveRotation);
        }

        if (Player.rotation.y == 0 && !hasTurned)
        {
            rotation = 90 - (adaptiveRotation - 90);
            hasTurned = true;
        }
        else if (Input.GetButton("FireDirectionUp") && rotation <= 80 && Player.rotation.y == 0)
        {
            rotation += 1;
            ShootDirection.rotation = Quaternion.Euler(0, 0, rotation);
        }
        else if (Input.GetButton("FireDirectionDown") && rotation >= 0 && Player.rotation.y == 0)
        {
            rotation -= 1;
            ShootDirection.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }

    void ShootForce()
    {
        if (flatRotation <= 45 && flatRotation >= 0)
        {
            xForce = 1;
            yForce = flatRotation / 45;
        }
        else if (flatRotation > 45 && flatRotation <= 90)
        {
            yForce = 1;
            xForce = 1 - ((flatRotation - 45) / 45);
        }
        else if(flatRotation > 90 && flatRotation <= 135)
        {
            yForce = 1;
            xForce = -((flatRotation - 90) / 45);
        }
        else if(flatRotation > 135)
        {
            xForce = -1;
            yForce = (1 - ((flatRotation - 135) / 45));
        }
    }

}
