using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public bool unlocksDoor;
    public GameObject door;
    public bool pickUp;

    private GameObject pressE;
    private bool isNear;

    private void Start()
    {
        pressE = GameObject.Find("PressE");
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("e")) {
            isNear = false;
            pickUp = true;
            GetComponent<AudioSource>().Play();
            GetComponent<Collider>().enabled = false;
            GetComponent<SelectedFlash>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            pressE.GetComponent<Text>().enabled = false;

            if (unlocksDoor)
            {
                door.GetComponent<DoorController>().locked = false;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        isNear = true;
        pressE.GetComponent<Text>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
        pressE.GetComponent<Text>().enabled = false;
    }
}
