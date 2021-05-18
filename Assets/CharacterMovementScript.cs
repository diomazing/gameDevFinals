using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public AudioSource movementSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            movementSound.Play();
        }
        else if (Input.GetKeyDown("w"))
        {
            movementSound.Play();
        }
        else if (Input.GetKeyDown("s"))
        {
            movementSound.Play();
        }
        else if (Input.GetKeyDown("d"))
        {
            movementSound.Play();
        }
    }
}
