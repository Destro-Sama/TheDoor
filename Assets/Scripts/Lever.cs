using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool on;
    public LockedDoor lockedDoor;
    public GameObject player;

    private Renderer leverRenderer;

    public Material leverOn;
    public Material leverOff;

    private void Start()
    {
        leverRenderer = gameObject.GetComponent<Renderer>();
    }

    public void PressSwitch()
    {
        on = on == true ? false : true;
        if (on == true)
        {
            lockedDoor.OpenDoor();
            leverRenderer.material = leverOn;
        }
        else
        {
            lockedDoor.CloseDoor();
            leverRenderer.material = leverOff;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 3f && Input.GetKeyDown(KeyCode.F))
        {
            PressSwitch();
        }
    }
}
