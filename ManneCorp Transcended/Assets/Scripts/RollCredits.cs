using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollCredits : MonoBehaviour
{
    public GameObject[] pages;

    private float waitTime = 5f, lastTimeChecked;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastTimeChecked = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasTimePassed())
        {
            if (index >= pages.Length)
            {
                ReturnToMenu();
            }
            else if (index + 1 < pages.Length)
            {
                pages[index + 1].SetActive(true);
                pages[index].SetActive(false);

            }
            index++;
            lastTimeChecked = Time.time;
        }
    }

    private bool HasTimePassed()
    {
        return Time.time - lastTimeChecked > waitTime;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
