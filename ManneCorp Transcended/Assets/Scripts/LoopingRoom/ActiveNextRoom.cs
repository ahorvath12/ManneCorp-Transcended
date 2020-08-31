using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNextRoom : MonoBehaviour
{
    public GameObject room;
    public string roomTag;

    private PickUpItem pickUpScript;
    private Renderer rend;
    private GameObject[] hideWithTag;
    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        room.SetActive(false);
        pickUpScript = GetComponent<PickUpItem>();
        rend = GetComponent<Renderer>();

        hideWithTag = GameObject.FindGameObjectsWithTag(roomTag);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpScript.pickUp && !activated) {
            activated = true;
            room.SetActive(true);
            Debug.Log("set up room");

            foreach (GameObject go in hideWithTag)
                go.SetActive(false);

            GameObject.FindWithTag("SueDoll").GetComponent<EndLoopingRoom>().revealWithTag = hideWithTag;
        }
    }
}
