﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNextRoom : MonoBehaviour
{
    public GameObject hideAtStart;

    private GameObject player;
    private bool openDoor;
    private float timeNeeded, lastTimeChecked;

    // Start is called before the first frame update
    void Start()
    {
        hideAtStart.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor && Input.GetKeyDown("e"))
        {
            GetComponent<Animator>().SetBool("open", openDoor);
            openDoor = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            GameObject.Find("PressE").GetComponent<Text>().enabled = true;
            openDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            GameObject.Find("PressE").GetComponent<Text>().enabled = false;
            openDoor = false;
        }
    }

    public void FullyStartArea()
    {
        GetComponent<Animator>().SetBool("open", false);
        hideAtStart.SetActive(true);
        GameObject.Find("house").GetComponent<HideHouse>().Hide();
    }
    
}