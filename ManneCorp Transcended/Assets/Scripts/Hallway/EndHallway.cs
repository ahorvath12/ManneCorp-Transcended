using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EndHallway : MonoBehaviour
{
    public GameObject player, hallway;
    public string roomTag1, roomTag2, roomTag3;

    private bool hidden;
    private GameObject[] revealWithTag1, revealWithTag2, revealWithTag3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        revealWithTag1 = GameObject.FindGameObjectsWithTag(roomTag1);
        revealWithTag2 = GameObject.FindGameObjectsWithTag(roomTag2);
        revealWithTag3 = GameObject.FindGameObjectsWithTag(roomTag3);
    }

    // Update is called once per frame
    void Update()
    {
        if (hidden)
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<FirstPersonController>().ReInitMouseLook();
        }
    }

    public void HideHallway()
    {
        hallway.SetActive(false);
        foreach (GameObject go in revealWithTag1)
            go.SetActive(true);

        foreach (GameObject go in revealWithTag2)
            go.SetActive(true);

        foreach (GameObject go in revealWithTag3)
            go.SetActive(true);

        hidden = true;
        player.GetComponent<FadeToBlack>().AbruptAppear();
    }
}
