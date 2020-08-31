using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBasement : MonoBehaviour
{
    public GameObject card, lines;

    private bool isNear, hasSaidLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && !hasSaidLine && card.GetComponent<PickUpItem>().pickUp)
        {
            lines.GetComponent<DetectiveVoiceManager>().SayLine(5);
            hasSaidLine = true;
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
