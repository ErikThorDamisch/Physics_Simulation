using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject canvas;
    bool IsActive;
	
	void Update ()
    {
        if (Input.GetButtonDown("Cancel") && !IsActive)
        {
            Cursor.visible = true;
            canvas.SetActive(true);
            IsActive = true;
        }
        else if (Input.GetButtonDown("Cancel") && IsActive)
        {
            Cursor.visible = false;
            canvas.SetActive(false);
            IsActive = false;
        }

    }
}
