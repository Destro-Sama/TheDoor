using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorTalk : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject theDoor;

    public GameObject doorCanvas;
    public TMP_Text doorText;
    public TMP_Text doorPunchLine;

    private List<string> doorTalks = new List<string>();
    private List<Vector3> positions = new List<Vector3>();
    private int positionIndex = 0;

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        theDoor = GameObject.Find("TheDoor");

        doorCanvas = GameObject.Find("TurnBack Canavs").transform.GetChild(0).gameObject;
        doorText = doorCanvas.transform.GetChild(3).gameObject.GetComponent<TMP_Text>();
        doorPunchLine = doorCanvas.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();

        positions.Add(new Vector3(27.67f, -0.21f, -1.04f));
        doorTalks.Add("Beware, Once You Enter, There Is No Going Back!");

        positions.Add(new Vector3(113.15f, -0.21f, -1.04f));
        doorTalks.Add("So.. You Made It Through The Obstacles.. But You Can't Get Through This Maze!");

        positions.Add(new Vector3(191.29f, -0.21f, -1.04f));
        doorTalks.Add("I See.. You Are Quite Cunning. But You Wont Be Able To Get Passed This!");

        positions.Add(new Vector3(264.1f, -0.21f, -1.04f));
        doorTalks.Add("Well... Smarter Than I Had Thought. There Is No Turning Back Now! Take This!!");

        positions.Add(new Vector3(352.1f, -0.21f, -1.04f));
        doorTalks.Add("Well, Well, Well.. I See You're Getting Used To Not Going Back!, But I've Got You Now!");

        positions.Add(new Vector3(404.1f, -0.21f, -1.04f));
        doorTalks.Add("How Did You Like That!! All Those Lasers And Fire!");

        positions.Add(new Vector3(410f, -0.21f, -1.04f));
        doorTalks.Add("What Do You Mean There Was Nothing There!!.. Ugh, Fine! Just Don't Touch The Walls...");

        positions.Add(new Vector3(608.7f, -0.21f, -1.04f));
        doorTalks.Add("How Careful Of You... One Final Challenge!!! Everything Together!");

        positions.Add(new Vector3(752.1f, -0.21f, -1.04f));
        doorTalks.Add("Congrats Kiddo, You Made It Through The Trials Of THE DOOR, I Think It's Time We Stop Pretending And Go Downstairs For Some Dinner?");

        positions.Add(new Vector3(1000f, -0.21f, -1.04f));
        doorTalks.Add("");

        theDoor.transform.position = positions[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        playerMovement.SetPause();
        doorCanvas.SetActive(true);
        doorText.text = doorTalks[positionIndex];
        doorPunchLine.text = "";
        StartCoroutine(EndPause());
        StartCoroutine(MoveDoor());
    }

    private IEnumerator EndPause()
    {
        yield return new WaitForSecondsRealtime(3f);
        doorCanvas.SetActive(false);
        playerMovement.SetPause();
    }

    private IEnumerator MoveDoor()
    {
        yield return new WaitForSecondsRealtime(3f);
        positionIndex += 1;
        theDoor.transform.position = positions[positionIndex];
    }
}
