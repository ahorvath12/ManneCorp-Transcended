using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInstructions : MonoBehaviour
{
    private bool hasShown;
    private float waitTime = 3, lastTimeChecked;

    // Update is called once per frame
    void Update()
    {
        if (hasShown && Time.time - lastTimeChecked > waitTime)
        {
            GetComponent<Text>().enabled = false;
        }
    }

    public void ShowText()
    {
        lastTimeChecked = Time.time;
        hasShown = true;
        GetComponent<Text>().enabled = true;
    }
}
