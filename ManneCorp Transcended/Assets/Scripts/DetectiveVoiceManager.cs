using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectiveVoiceManager : MonoBehaviour
{
    public GameObject[] subs;
    public AudioClip[] lines;

    private AudioSource audioSource;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            subs[index].GetComponent<Text>().enabled = false;
        }
    }


    public void SayLine(int i) {
        subs[i].GetComponent<Text>().enabled = true;
        audioSource.clip = lines[i];
        audioSource.Play();
        index = i;
    }


}
