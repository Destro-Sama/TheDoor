using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTalk : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject theDoor;
    private int state = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (state == 1)
        {
            state += 1;
            playerMovement.SetPause();
            Debug.Log("Beware, Once You Enter, There Is No Going Back!");
            StartCoroutine(EndPause());
            StartCoroutine(MoveDoor());
        }
    }

    private IEnumerator EndPause()
    {
        yield return new WaitForSecondsRealtime(3f);
        playerMovement.SetPause();
    }

    private IEnumerator MoveDoor()
    {
        if (state - 1 == 1)
        {
            yield return new WaitForSecondsRealtime(3f);
            theDoor.SetActive(false);
        }
    }
}
