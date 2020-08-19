using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool locked = false;
    public GameObject player;

    private Animator anim;
    bool canOpen = false, isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && !locked)
        {
            if (Input.GetKeyDown("e"))
            {
                isOpen = !isOpen;
                anim.SetBool("open", isOpen);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            canOpen = false;
    }


}
