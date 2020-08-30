using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomKey : MonoBehaviour
{
    public GameObject lines;

    private PickUpItem pickUp;
    private bool hasSaidLine;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GetComponent<PickUpItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.pickUp && !hasSaidLine)
        {
            Debug.Log(pickUp.pickUp);
            hasSaidLine = true;
            lines.GetComponent<DetectiveVoiceManager>().SayLine(3);
        }
    }
}
