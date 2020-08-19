using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public bool unlocksDoor;
    public GameObject door;

    bool pickUp;
    

    // Update is called once per frame
    void Update()
    {
        if (pickUp && Input.GetKeyDown("e")) {
            pickUp = false;
            GetComponent<AudioSource>().Play();
            GetComponent<Collider>().enabled = false;
            GetComponent<SelectedFlash>().enabled = false;
            GetComponent<Renderer>().enabled = false;

            if(unlocksDoor)
            {
                door.GetComponent<DoorController>().locked = false;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        pickUp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        pickUp = false;
    }
}
