using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    GameManager gm;

    public bool timerIsRunning;
    [HideInInspector]
    public float currentTime;

    private void Start()
    {
        //setWinner = GameObject.FindWithTag("GameController").GetComponent<SetWinner>();
        // Starts the timer automatically
        gm = GetComponent<GameManager>();
        timerIsRunning = true;
        currentTime = gm.roundDurationInSec;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (currentTime > 0 && gm.GameMode != GameManager.gameModes.ROUNDOVER)
            {
                currentTime -= Time.deltaTime;
                DisplayTime(currentTime);
            }
            else
            {
                gm.GameMode = GameManager.gameModes.ROUNDOVER;
                Debug.Log("Time has run out!");
                currentTime = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
