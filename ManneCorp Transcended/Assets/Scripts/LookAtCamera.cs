using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject player;

    Renderer rend;
    bool startLooking = false;
    float speed = 1f, singleStep;
    Vector3 targetDirection, newDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
            startLooking = true;
        else if (startLooking && !rend.isVisible)
        {
            targetDirection = player.transform.position - transform.position;
            singleStep = speed * Time.deltaTime;
            newDirection = Vector3.RotateTowards(transform.forward, targetDirection, .1f, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
