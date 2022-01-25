using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTalk : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject theDoor;

    private List<string> doorTalks = new List<string>();
    private List<Vector3> positions = new List<Vector3>();
    private int positionIndex = 0;

    private void Start()
    {
        positions.Add(new Vector3(27.67f, -0.21f, -1.04f));
        doorTalks.Add("Beware, Once You Enter, There Is No Going Back!");

        positions.Add(new Vector3(113.15f, -0.21f, -1.04f));
        doorTalks.Add("So.. You Made It Through The Obstacles.. But You Can't Get Passed This!");

        theDoor.transform.position = positions[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        playerMovement.SetPause();
        Debug.Log(doorTalks[positionIndex]);
        StartCoroutine(EndPause());
        StartCoroutine(MoveDoor());
    }

    private IEnumerator EndPause()
    {
        yield return new WaitForSecondsRealtime(3f);
        playerMovement.SetPause();
    }

    private IEnumerator MoveDoor()
    {
        yield return new WaitForSecondsRealtime(3f);
        positionIndex += 1;
        theDoor.transform.position = positions[positionIndex];
    }
}
