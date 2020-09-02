﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasetteSubs : MonoBehaviour
{
    public GameObject[] subs;
    public GameObject skipText;

    int index = 0;
    bool show;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && show == true)
        {
            HideText(index);
        }
    }

    public void ShowText(int i)
    {
        index = i;
        subs[index].SetActive(true);
        skipText.GetComponent<Text>().enabled = true;
        show = true;
    }

    public void HideText(int i)
    {
        subs[i].SetActive(false);
        skipText.GetComponent<Text>().enabled = false;
        show = false;
    }
}
