using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public float fieldOfView = 360f;
    public GameObject player;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public GameObject placeholder;

    private Transform target;
    private Vector3 lastSeenPos;
    private NavMeshAgent agent;
    private float timer;
    private bool foundTarget, targetSighted;
    
    private SphereCollider col;

    private void Start()
    {
        StartCoroutine("FindTargetWithDelay", 0.2f);
    }

    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTarget();
        }
    }
    

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        col = GetComponent<SphereCollider>();
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (foundTarget)
        {
            lastSeenPos = player.transform.position;
            agent.SetDestination(lastSeenPos);
            targetSighted = true;
        }
        else if (targetSighted)
        {
            agent.SetDestination(lastSeenPos);
        }
        if (transform.position == lastSeenPos)
        {
            targetSighted = false;
        }
        else if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<FadeToBlack>().AbruptAppear();
            player.transform.position = placeholder.transform.position;
            player.transform.rotation = placeholder.transform.rotation;
        }
    }

    private void FindTarget()
    {
        Transform target = player.transform;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
        {
            Debug.Log("target found");
            foundTarget = true;
        }
        Debug.Log("target not found");
        foundTarget = false;
    }
}
