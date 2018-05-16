using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScriptPlayer2 : MonoBehaviour
{
    public Rigidbody2D Rock;
    public Transform ShootDirection;
    public Slider powerSlider;
    GameObject gameManager;
    RoundScript roundScript;
    Rigidbody2D rb;
    Transform ShotOrigin;
    int speed = 10;
    float rotation;
    float adaptiveRotation;
    bool hasTurned;
    float flatRotation;
    float xForce;
    float yForce;
    float time;
    float firePower;

    void Start()
    {
        ShotOrigin = GameObject.Find("ShotOrigin1").transform;
        hasTurned = true;
        gameManager = GameObject.Find("GameManager");
        roundScript = gameManager.GetComponent<RoundScript>();
    }

    void Update()
    {
        flatRotation = ShootDirection.rotation.eulerAngles.z;
        RotateShootDirection();
        FireArrow();
        powerSlider.value = time / 3;
    }

    void FireArrow()
    {
        if (Input.GetButton("FirePower") && time <= 3)
        {
            time += Time.deltaTime;
        }

        if (Input.GetButtonUp("FirePower") && time > 0)
        {
            firePower = (time * 100) / 3;
            ShootForce();
            Rigidbody2D ArrowClone = (Rigidbody2D)Instantiate(Rock, ShotOrigin.position, Quaternion.Euler(0, 0, 0));
            ArrowClone.AddForce(new Vector2(xForce * firePower, yForce * firePower));
            roundScript.whosTurn = true;
            time = 0;
        }
    }

    void RotateShootDirection()
    {
        if (transform.rotation.y == -1 && hasTurned)
        {
            adaptiveRotation = 90 + (90 - rotation);
            ShootDirection.rotation = Quaternion.Euler(0, 0, adaptiveRotation);
            hasTurned = false;
        }
        else if (transform.rotation.y == -1 && Input.GetButton("FireDirectionUp") && adaptiveRotation >= 100)
        {
            adaptiveRotation -= 1;
            ShootDirection.rotation = Quaternion.Euler(0, 0, adaptiveRotation);
        }
        else if ((transform.rotation.y == -1 && Input.GetButton("FireDirectionDown") && adaptiveRotation <= 179))
        {
            adaptiveRotation += 1;
            ShootDirection.rotation = Quaternion.Euler(0, 0, adaptiveRotation);
        }

        if (transform.rotation.y == 0 && !hasTurned)
        {
            rotation = 90 - (adaptiveRotation - 90);
            ShootDirection.rotation = Quaternion.Euler(0, 0, rotation);
            hasTurned = true;
        }
        else if (Input.GetButton("FireDirectionUp") && rotation <= 80 && transform.rotation.y == 0)
        {
            rotation += 1;
            ShootDirection.rotation = Quaternion.Euler(0, 0, rotation);
        }
        else if (Input.GetButton("FireDirectionDown") && rotation >= 1 && transform.rotation.y == 0)
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
        else if (flatRotation > 90 && flatRotation <= 135)
        {
            yForce = 1;
            xForce = -((flatRotation - 90) / 45);
        }
        else if (flatRotation > 135)
        {
            xForce = -1;
            yForce = (1 - ((flatRotation - 135) / 45));
        }
    }
}
