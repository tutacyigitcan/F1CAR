using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleSound : MonoBehaviour
{
    private AudioSource Player;

    private void Start()
    {
        Player = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (SaveScript.Rumble1 == true || SaveScript.Rumble2 == true)
        {
            Player.Play();
        }
        else
        {
            Player.Stop();
        }
    }
}
