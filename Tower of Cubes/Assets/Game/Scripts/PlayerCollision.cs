using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    AudioSource sound;

    private void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "RedCube")
        {
            sound.Play();
        }
    }
}
