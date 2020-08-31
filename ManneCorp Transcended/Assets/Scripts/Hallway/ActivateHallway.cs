using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHallway : MonoBehaviour
{
    public GameObject room;
    public string roomTag1, roomTag2, roomTag3;

    private PickUpItem pickUpScript;
    private Renderer rend;
    private GameObject[] hideWithTag1, hideWithTag2, hideWithTag3;
    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        room.SetActive(false);
        pickUpScript = GetComponent<PickUpItem>();
        rend = GetComponent<Renderer>();

        hideWithTag1 = GameObject.FindGameObjectsWithTag(roomTag1);
        hideWithTag2 = GameObject.FindGameObjectsWithTag(roomTag2);
        hideWithTag3 = GameObject.FindGameObjectsWithTag(roomTag3);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpScript.pickUp && !activated)
        {
            activated = true;
            room.SetActive(true);

            foreach (GameObject go in hideWithTag1)
                go.SetActive(false);

            foreach (GameObject go in hideWithTag2)
                go.SetActive(false);

            foreach (GameObject go in hideWithTag3)
                go.SetActive(false);
        }
    }
}
