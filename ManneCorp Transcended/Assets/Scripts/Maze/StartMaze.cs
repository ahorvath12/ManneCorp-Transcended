using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMaze : MonoBehaviour
{
    public GameObject maze, meshGO, card, note;
    public string roomTag1, roomTag2, roomTag3;
    public bool startMaze;

    private Renderer rend;
    private GameObject[] hideWithTag1, hideWithTag2, hideWithTag3;
    private bool isNear, mazeOpened, open;

    // Start is called before the first frame update
    void Start()
    {
        rend = meshGO.GetComponent<Renderer>();
        note = GameObject.Find("Reverse");

        hideWithTag1 = GameObject.FindGameObjectsWithTag(roomTag1);
        hideWithTag2 = GameObject.FindGameObjectsWithTag(roomTag2);
        hideWithTag3 = GameObject.FindGameObjectsWithTag(roomTag3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && card.GetComponent<PickUpItem>().pickUp)
        {
            GetComponent<Animator>().SetBool("open", false);
            open = true;
        }

        if (isNear && Input.GetKeyDown("e") && open)
        {
            GetComponent<Animator>().SetBool("open", true);
            foreach (GameObject mannequin in GameObject.Find("Basement").GetComponent<BasementController>().mannequins)
            {
                mannequin.GetComponent<DollController>().ReturnToOrigin();
                mannequin.GetComponent<DollController>().enabled = false;
            }

            maze.SetActive(true);

            foreach (GameObject go in hideWithTag1)
                go.SetActive(false);

            foreach (GameObject go in hideWithTag2)
                go.SetActive(false);

            foreach (GameObject go in hideWithTag3)
                go.SetActive(false);

            mazeOpened = true;
        }

        if (mazeOpened && !rend.isVisible)
        {
            foreach (GameObject go in hideWithTag1)
                go.SetActive(true);

            foreach (GameObject go in hideWithTag2)
                go.SetActive(true);

            foreach (GameObject go in hideWithTag3)
                go.SetActive(true);

            GameObject.Find("house").GetComponent<HideHouse>().Hide();
            note.GetComponent<ShowInstructions>().ShowText();
            GetComponent<StartMaze>().enabled = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isNear = true;
        Debug.Log("is near");
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}
