using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseUI, player;
    public GameObject[] buttons;

    private bool paused = false;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;
                player.GetComponent<FirstPersonController>().enabled = false;
                index = 0;
                buttons[index].GetComponent<Text>().color = Color.red;
            }
            else
            {
                paused = false;
                pauseUI.SetActive(false);
                Time.timeScale = 1;
                AudioListener.pause = false;
                player.GetComponent<FirstPersonController>().enabled = true;
            }
        }

        if (paused)
        {
            if (Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow) )
            {
                buttons[index].GetComponent<Text>().color = Color.white;
                index++;
                if (index == buttons.Length)
                    index = 0;
                buttons[index].GetComponent<Text>().color = Color.red;
            }
            else if (Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow))
            {
                buttons[index].GetComponent<Text>().color = Color.white;
                index--;
                if (index == -1)
                    index = buttons.Length-1;
                buttons[index].GetComponent<Text>().color = Color.red;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (index == 0)
                {
                    paused = false;
                    pauseUI.SetActive(false);
                    Time.timeScale = 0;
                    AudioListener.pause = false;
                    player.GetComponent<FirstPersonController>().enabled = true;
                }
                else
                {
                    Application.Quit();
                }
            }
        }
    }

    public void Resume()
    {
        //resume
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
