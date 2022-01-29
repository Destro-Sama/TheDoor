using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public GameObject endCanvas;
    public TMP_Text resets;
    public TMP_Text turnBacks;

    public PlayerMovement player;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        endCanvas.SetActive(true);
        resets.text = $"Resets: {player.resets}";
        turnBacks.text = $"Turn Back Attempts: {player.turnBackAttempts}";
    }
}
