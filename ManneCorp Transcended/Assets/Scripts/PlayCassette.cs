using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCassette : MonoBehaviour
{
    private AudioSource audioSource;
    private PickUpItem pickUp;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pickUp = GetComponent<PickUpItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.pickUp)
            audioSource.Play();
    }
}
