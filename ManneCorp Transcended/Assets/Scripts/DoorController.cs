using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public bool locked = false;
    public GameObject player, pressE, lockedText;

    private Animator anim;
    bool canOpen = false, isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 1.5f;
        pressE = GameObject.Find("PressE");
        lockedText = GameObject.Find("LockedDoor");
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && !locked)
        {
            if (Input.GetKeyDown("e") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
            {
                isOpen = !isOpen;
                anim.SetBool("open", isOpen);
                pressE.GetComponent<Text>().enabled = false;
                GetComponent<AudioSource>().Play();
            }
        }
        if (canOpen && locked && Input.GetKeyDown("e"))
        {
            pressE.GetComponent<Text>().enabled = false;
            lockedText.GetComponent<Text>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            canOpen = true;
            pressE.GetComponent<Text>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            canOpen = false;
            pressE.GetComponent<Text>().enabled = false;
            lockedText.GetComponent<Text>().enabled = false;

        }
    }


}
