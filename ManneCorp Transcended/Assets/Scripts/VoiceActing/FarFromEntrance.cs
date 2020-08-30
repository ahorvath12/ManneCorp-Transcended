using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarFromEntrance : MonoBehaviour
{
    public GameObject player, lineCanvas;

    private bool hasSaidLine;

    // Update is called once per frame
    void Update()
    {
        if (!hasSaidLine && Vector3.Distance(transform.position, player.transform.position) > 10)
        {
            hasSaidLine = true;
            lineCanvas.GetComponent<DetectiveVoiceManager>().SayLine(0);
        }
    }
}
