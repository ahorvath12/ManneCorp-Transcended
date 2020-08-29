using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementController : MonoBehaviour
{
    public GameObject player, card;
    public GameObject[] mannequins;

    private Animator[] dollAnimators;
    private int dollIndex = 4;
    // Start is called before the first frame update
    void Start()
    {
        dollAnimators = new Animator[mannequins.Length];
        for (int i = 0; i < mannequins.Length; i++)
        {
            dollAnimators[i] = mannequins[i].GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(card.GetComponent<PickUpItem>().pickUp)
        {
            StartMoving();
        }
    }

    public void StartMoving()
    {
        for(int i = 0; i < dollIndex; i++)
        {
            mannequins[i].GetComponent<DollController>().StartMoving();
        }
    }

    public void ReturnToOrigin()
    {
        for (int i = 0; i < dollIndex; i++)
        {
            //do something
        }
    }
}
