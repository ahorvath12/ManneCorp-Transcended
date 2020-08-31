using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ReadCard : MonoBehaviour
{
    public GameObject cardUI, player, safe;
    public bool hasSeen, putDown;

    private PickUpItem pickUp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pickUp = GetComponent<PickUpItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.pickUp && !hasSeen)
        {
            hasSeen = true;
            cardUI.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = false;
            safe.GetComponent<SafeManager>().locked = false;
        }

        else if (hasSeen && Input.GetKeyDown("e"))
        {
            putDown = true;
            cardUI.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}
