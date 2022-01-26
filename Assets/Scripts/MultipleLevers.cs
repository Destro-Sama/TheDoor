using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleLevers : MonoBehaviour
{
    private bool on;
    public LockedDoor lockedDoor;
    public GameObject player;

    private Renderer leverRenderer;

    public Material leverOn;
    public Material leverOff;

    public MultipleLevers[] levers;

    private int leverAmount;
    public int leverIndex;
    private static int nextIndex = 1;

    private void Start()
    {
        leverRenderer = gameObject.GetComponent<Renderer>();
        leverAmount = levers.Length;
    }

    private void PressSwitch()
    {
        if (leverIndex != nextIndex)
        {
            on = false;
            foreach (var lever in levers)
            {
                lever.SetInactive();
            }
        }
        else
        {
            on = true;
            if (nextIndex == leverAmount)
            {
                nextIndex = 1;
                lockedDoor.OpenDoor();
                foreach (var lever in levers)
                {
                    lever.gameObject.SetActive(false);
                }
                return;
            }
            nextIndex += 1;
        }


        if (on == true)
        {
            leverRenderer.material = leverOn;
        }
        else
        {
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

    public void SetInactive()
    {
        on = false;
        leverRenderer.material = leverOff;

    }
}
