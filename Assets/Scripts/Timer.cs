using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 360;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over");
        //SceneManager.LoadScene(1); // it will reload ur scene, probably this will work as a game restart for your project, you should do some better "game ending thingy" tho
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // timeText = GetComponent<Text>();
        timeText.text=string.Format("{0:00}:{1:00}", minutes, seconds);
        // timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}