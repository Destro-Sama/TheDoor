using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    private void Start()
    {
        Physics.queriesHitTriggers = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerMovement>().ChangeDirection();
        Destroy(gameObject, 0.1f);
    }
}
