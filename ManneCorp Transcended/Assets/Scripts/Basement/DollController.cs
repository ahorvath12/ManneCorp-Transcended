using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DollController : MonoBehaviour
{
    public GameObject player;
    public GameObject meshGO;
    public AudioClip[] clips;

    private Animator anim;
    private NavMeshAgent agent;
    private AudioSource audioSource;
    private Vector3 startingPos, curPos, lastPos;
    private Quaternion startingRot;
    private Renderer rend;
    bool canMove = false;
    int pose;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rend = meshGO.GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            lastPos = curPos;
            if(rend.isVisible)
            {
                agent.isStopped = true;
                audioSource.Stop();
            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
                pose = Random.Range(1, 4);
                anim.SetInteger("poseNum", pose);
            }

            curPos = gameObject.transform.position;
            if (curPos != lastPos && !audioSource.isPlaying)
            {
                int index = Random.Range(0, clips.Length);
                audioSource.clip = clips[index];
                audioSource.Play();
            }
        }
    }

    public void StartMoving()
    {
        anim.SetTrigger("startMoving");
        canMove = true;
    }

    public void ReturnToOrigin()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("killed player");
        }
    }
}
