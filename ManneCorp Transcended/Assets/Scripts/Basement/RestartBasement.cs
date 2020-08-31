using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RestartBasement : MonoBehaviour
{
    public GameObject player, card, lines, safe;
    public GameObject[] mannequins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        lines.GetComponent<DetectiveVoiceManager>().SayLine(6);
        player.GetComponent<FadeToBlack>().AbruptAppear();
        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;

        foreach (GameObject go in mannequins)
        {
            go.GetComponent<DollController>().ReturnToOrigin();
            go.GetComponent<DollController>().canMove = false;
            go.GetComponent<NavMeshAgent>().enabled = true;
        }

        card.GetComponent<Collider>().enabled = true;
        card.GetComponent<SelectedFlash>().enabled = true;
        card.GetComponent<Renderer>().enabled = true;
        card.GetComponent<PickUpItem>().pickUp = false;
        card.GetComponent<ReadCard>().hasSeen = false;

        safe.GetComponent<SafeManager>().locked = true;
    }
}
