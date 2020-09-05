using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildDollController : MonoBehaviour
{
    public GameObject player;
    public GameObject meshGO;
    public GameObject flash;
    public AudioClip[] clips;
    
    private NavMeshAgent agent;
    private AudioSource audioSource;
    private Vector3 startingPos;
    private Quaternion startingRot;
    private Renderer rend;
    bool canMove;
    int pose;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startingPos = transform.position;
        startingRot = transform.rotation;

        flash = GameObject.Find("Flash");
        
        agent = GetComponent<NavMeshAgent>();
        rend = meshGO.GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rend.isVisible)
        {
            agent.isStopped = true;
            if (Input.GetKeyDown("space") && flash.GetComponent<Flashbang>().flash)
            {
                //audioSource.Stop();
                ReturnToOrigin();
            }
            if (!canMove)
                canMove = true;
        }
        else
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            //audioSource.Play();
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
    }

    private void ReturnToOrigin()
    {
        transform.position = startingPos;
        transform.rotation = startingRot;
    }
}
