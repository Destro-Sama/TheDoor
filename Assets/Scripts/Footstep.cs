using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{

    private CharacterController cc;
    private AudioSource footstep;

    private float footstepCooldown;
    private float footstepTimer = 0.5f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        footstep = GetComponent<AudioSource>();
    }

    private void Update()
    {
        footstepCooldown -= Time.deltaTime;
        if (cc.isGrounded && cc.velocity.magnitude > 2f && footstepCooldown <= 0)
        {
            footstep.pitch = Random.Range(0.8f, 1.1f);
            footstep.volume = Random.Range(0.4f, 0.6f);
            footstep.Play();
            footstepCooldown = footstepTimer;
        }
    }
}
