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

        jokes.Add("Test");
        punchLines.Add("Because Test");
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
        yield return new WaitForSeconds(1f);
        joke.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        punchLine.gameObject.SetActive(true);
    }
}
