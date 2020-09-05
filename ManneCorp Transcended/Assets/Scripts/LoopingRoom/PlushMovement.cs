using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlushMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject flash;
    public AudioClip[] clips;

    private Renderer rend;
    private NavMeshAgent agent;
    private AudioSource audioSource;
    private Vector3 startingPos;
    private Quaternion startingRot;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        startingRot = transform.rotation;

        player = GameObject.FindWithTag("Player");
        flash = GameObject.Find("Flash");

        rend = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
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
                ReturnToOrigin();
            }
        }
        else
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
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
