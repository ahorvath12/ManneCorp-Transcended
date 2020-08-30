using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToTape : MonoBehaviour
{
    public GameObject lines;

    private AudioSource audioSource;

    private bool hasPlayed, hasSaidLine;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
            hasPlayed = true;
        else if (!audioSource.isPlaying && hasPlayed && !hasSaidLine)
        {
            lines.GetComponent<DetectiveVoiceManager>().SayLine(2);
            hasSaidLine = true;
        }
    }
}
