using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectiveVoiceManager : MonoBehaviour
{
    public GameObject[] subs;
    public AudioClip[] lines;
    public bool sayLine;

    private AudioSource audioSource;
    private int index = 0;
    private bool hasSaidLine;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sayLine)
        {
            sayLine = false;
            subs[index].GetComponent<Text>().enabled = true;
            audioSource.clip = lines[index];
            audioSource.Play();
            hasSaidLine = true;
        }
        if (!audioSource.isPlaying && hasSaidLine)
        {
            subs[index].GetComponent<Text>().enabled = false;
            hasSaidLine = false;
            index++;
        }
    }


}
