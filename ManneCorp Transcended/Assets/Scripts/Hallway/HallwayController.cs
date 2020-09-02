using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HallwayController : MonoBehaviour
{
    //public GameObject oldWall, newWall;
    public GameObject wallR, wallL, player, placeholder, doorToHall;
    public GameObject[] lights;

    int count;
    float movementSpeed = 0.1f, timeBreak = 25, timeInterval = 0.5f, timeStart, lastTimeChecked;
    bool moveWalls, turnOffLights, timeToStart, restart;
    Vector3 initialLocation, wallLLocation, wallRLocation;
    Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        moveWalls = false;
        turnOffLights = false;
        timeToStart = false;
        restart = false;
        count = lights.Length;
        initialLocation = placeholder.transform.position;
        initialRotation = placeholder.transform.rotation;
        wallLLocation = wallL.transform.position;
        wallRLocation = wallR.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (restart && player.transform.position == initialLocation)
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<FirstPersonController>().ReInitMouseLook();
            restart = false;
            Debug.Log("restarted");
        }

        if (moveWalls)
        {
            SqueezeWallsTogether();
            if (count == lights.Length)
            {
                timeToStart = true;
                count--;
            }
        }

        if (timeToStart && (Time.time - timeStart > timeBreak))
        {
            Debug.Log("break");
            turnOffLights = true;
            lastTimeChecked = Time.time;
            timeToStart = false;
        }
        else if (turnOffLights && TimeToBreak() && count >= 0)
        {
            BreakNextLight(count);
            count--;
            lastTimeChecked = Time.time;
        }
        else if (count < 0)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            ReinitializeLocations();
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().enabled = true;
            }
            count = lights.Length;
            turnOffLights = false;
            restart = true;
        }
    }

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("collided with player");
            moveWalls = true;
            timeStart = Time.time;
            doorToHall.GetComponent<Animator>().SetBool("open", false);
        }
    }

    private void SqueezeWallsTogether()
    {
        wallR.transform.position += Vector3.back * Time.deltaTime * movementSpeed;
        wallL.transform.position += Vector3.forward * Time.deltaTime * movementSpeed;

    }

    private void BreakNextLight(int index)
    {
        lights[count].GetComponent<Light>().enabled = false;
        lights[count].GetComponent<AudioSource>().Play(); ;
    }

    private bool TimeToBreak()
    {
        return Time.time - lastTimeChecked > timeInterval;
    }

    private void ReinitializeLocations()
    {
        moveWalls = false;
        
        player.transform.position = initialLocation;
        player.transform.rotation = initialRotation;

        wallR.transform.position = wallRLocation;

        wallL.transform.position = wallLLocation;



        placeholder.GetComponent<EndHallway>().HideHallway();
        //player.GetComponent<FirstPersonController>().enabled = true;
    }
}
