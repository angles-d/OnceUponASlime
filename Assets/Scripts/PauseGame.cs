using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject panel;
    public bool gamePaused = false;

    public AudioSource bgSound1;
    public AudioSource bgSound2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if p is pressed pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause_Play();
        }

    }

    public void Pause_Play()
    {
        if (!gamePaused)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            gamePaused = true;
            bgSound1.Pause();
            bgSound2.Pause();

        }
        else
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            gamePaused = false;
            bgSound1.Play();
            bgSound2.Play();
        }
    }

}