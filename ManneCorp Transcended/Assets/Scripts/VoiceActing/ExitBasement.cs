using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBasement : MonoBehaviour
{
    public GameObject card, lines;

    public GameObject[] mannequins;

    private bool isNear, hasSaidLine;

    // Start is called before the first frame update
    void Start()
    {
        mannequins = GameObject.FindGameObjectsWithTag("Mannequin");
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && !hasSaidLine && card.GetComponent<PickUpItem>().pickUp)
        {
            lines.GetComponent<DetectiveVoiceManager>().SayLine(5);
            hasSaidLine = true;

            foreach (GameObject go in mannequins)
            {
                go.GetComponent<DollController>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}
