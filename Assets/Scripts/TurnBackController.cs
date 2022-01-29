using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnBackController : MonoBehaviour
{
    public TMP_Text joke;
    public TMP_Text punchLine;

    private List<string> jokes = new List<string>();
    private List<string> punchLines = new List<string>();

    private void Start()
    {
        jokes.Add("Why Did The Chicken Cross The Road?");
        punchLines.Add("Because He Couldn't Go Back");

        jokes.Add("knock knock, knot, knot who");
        punchLines.Add("knot going back");

        jokes.Add("what do you call a fish with no eyes?");
        punchLines.Add("don't know, cant go back");

        jokes.Add("what do you call a can opener that doesn't work?");
        punchLines.Add("A can't go back opener!");

        jokes.Add("did you hear about the italian chef who died?");
        punchLines.Add("he didn't go back");

        jokes.Add("what's fuzzy and bad for your health?");
        punchLines.Add("going back!");

        jokes.Add("two guys walk into a bar!");
        punchLines.Add("the third guy goes back");

        jokes.Add("i used to be addicted to the hokey pokey");
        punchLines.Add("but then i didn't turn around");
    }

    public void Activate()
    {
        joke.gameObject.SetActive(false);
        punchLine.gameObject.SetActive(false);
        int index = Random.Range(0, jokes.Count);
        joke.text = jokes[index];
        punchLine.text = punchLines[index];
        transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(MakeJoke());
    }

    public void DeActivate()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        StopCoroutine(MakeJoke());
    }

    private IEnumerator MakeJoke()
    {
        joke.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        punchLine.gameObject.SetActive(true);
    }
}
