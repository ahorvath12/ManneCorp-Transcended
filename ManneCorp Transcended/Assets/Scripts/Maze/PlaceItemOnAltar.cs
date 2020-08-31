using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceItemOnAltar : MonoBehaviour
{
    public GameObject pressE, emptyInv, symbol, orb, placeholder, lines;
    public GameObject blood, book, flesh;


    private bool isClose, hasBlood, hasFlesh, hasBook, timeToSay, hasSaidLine;
    bool item1, item2, item3;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        blood.SetActive(false);
        book.SetActive(false);
        flesh.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(isClose && Input.GetKeyDown("e"))
        {
            if (!hasBlood && !hasBook && !hasFlesh)
            {
                pressE.GetComponent<Text>().enabled = false;
                emptyInv.GetComponent<Text>().enabled = true;
            }

            if (hasBlood)
            {
                hasBlood = false;
                item1 = true;
                blood.SetActive(true);
                count++;
            }
            if (hasBook)
            {
                hasBook = false;
                item2 = true;
                book.SetActive(true);
                count++;
            }
            if (hasFlesh)
            {
                hasFlesh = false;
                item3 = true;
                flesh.SetActive(true);
                count++;
            }
        }

        

        if (item1 && item2 && item3 && !timeToSay)
        {
            lines.GetComponent<DetectiveVoiceManager>().SayLine(7);
            hasSaidLine = true;
            timeToSay = true;
            count++;
        }

        if (hasSaidLine && !lines.GetComponent<AudioSource>().isPlaying)
        {
            hasSaidLine = false;
            symbol.SetActive(true);
            GetComponent<AudioSource>().Play();
            orb.GetComponent<WanderingAI>().enabled = false;
            StartCoroutine(GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>().Shake(3.25f, 0.2f));
            placeholder.GetComponent<EndMaze>().End();
            count++;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        isClose = true;
        pressE.GetComponent<Text>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isClose = false;
        pressE.GetComponent<Text>().enabled = false;
        emptyInv.GetComponent<Text>().enabled = false;
    }

    public void HasBlood()
    {
        hasBlood = true;
    }

    public void HasFlesh()
    {
        hasFlesh = true;
    }

    public void HasBook()
    {
        hasBook = true;

    }
}
