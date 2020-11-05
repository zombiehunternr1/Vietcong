﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force;
    private Rigidbody rb_Player;
    private StateHandler handler;
    private const float DEFAULTSTUN = 0.25f;
    private AudioClip PlayBounceSound;
    private AudioSource BounceSource;

    void Awake()
    {
        BounceSource = GetComponent<AudioSource>();
        PlayBounceSound = BounceSource.clip;
        rb_Player = GetComponentInParent<Rigidbody>();
        handler = GetComponentInParent<StateHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the players collide with eachother
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            BounceSource.PlayOneShot(PlayBounceSound, 0.7f);
            handler.SetCanAct(DEFAULTSTUN);
            Vector3 direction = (transform.position - other.transform.position).normalized;

            rb_Player.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
