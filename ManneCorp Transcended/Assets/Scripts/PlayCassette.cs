using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCassette : MonoBehaviour
{
    public GameObject subs;
    public GameObject[] tapes;
    public int index;

    private PickUpItem pickUp;
    bool hasShown, hide;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GetComponent<PickUpItem>();
        tapes = GameObject.FindGameObjectsWithTag("Tape");
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.pickUp && !hasShown)
        {
            foreach (GameObject go in tapes)
            {
                if (go != this.gameObject && go.GetComponent<AudioSource>().isPlaying)
                {
                    go.GetComponent<AudioSource>().Stop();

                }
            }

            hasShown = true;
            subs.GetComponent<CasetteSubs>().ShowText(index);
        }

        if (hasShown && !GetComponent<AudioSource>().isPlaying)
        {
            subs.GetComponent<CasetteSubs>().HideText(index);
        }
    }
}
