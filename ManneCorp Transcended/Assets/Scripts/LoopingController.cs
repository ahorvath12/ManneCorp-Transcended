using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LoopingController : MonoBehaviour
{
    public GameObject player, otherDoor, placeholderStart, placeholder, placeholderEnd, changingPainting;
    public Material[] plantsMats;
    public GameObject[] lights, lightsFake, paintingsPhase1, paintingsPhase2, paintingsPhase3, paintingsPhase4;

    bool canExit, restart, startLoop, slideForward;
    int phase, lightsInd;
    float moveSpeed = 1.5f;
    float waitTime = 3.5f, lastTimeChecked;
    Renderer plantRend;
    Color32[] colors;

    // Start is called before the first frame update
    void Start()
    {
        phase = 0;
        lightsInd = 0;
        plantRend = changingPainting.GetComponent<Renderer>();
        colors = new Color32[] { new Color32(255, 228, 228, 100), new Color32(255, 175, 175, 100), new Color32(255, 146, 146, 100) };
    }

    // Update is called once per frame
    void Update()
    {
        //on loop
        if (restart)
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<FirstPersonController>().ReInitMouseLook();

            restart = false;
            if (lightsInd > 0)
                ChangeLights(lightsFake, colors[lightsInd - 1]);
        }

        if (canExit && Input.GetKeyDown("e"))
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            Debug.Log("starting loop");
            startLoop = true;
        }

        //start player teleportationg
        if (startLoop)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, placeholderStart.transform.position, Time.deltaTime * moveSpeed);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, placeholderStart.transform.rotation, Time.deltaTime * moveSpeed);
        }
        if(startLoop && Vector3.Distance(player.transform.position, placeholderStart.transform.position) <= 0.1f)
        {
            phase++;
            lightsInd++;
            player.transform.position = placeholder.transform.position;
            player.transform.rotation = placeholder.transform.rotation;
            startLoop = false;
            slideForward = true;
            otherDoor.GetComponent<Animator>().SetBool("open", true);
            lastTimeChecked = Time.time;
        }

        //move player through door
        if (slideForward && CanSlideForward())
        {
            player.transform.position = Vector3.Lerp(player.transform.position, placeholderEnd.transform.position, Time.deltaTime * moveSpeed);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, placeholderEnd.transform.rotation, Time.deltaTime * moveSpeed);
        }
        if (slideForward && Vector3.Distance(player.transform.position, placeholderEnd.transform.position) <= 0.1f)
        {
            slideForward = false;
            restart = true;
            otherDoor.GetComponent<Animator>().SetBool("open", false);
        }

        //change environment depending on phase
        switch (phase)
        {
            case 1:
                break;
            case 2:
                plantRend.materials = SwitchPlantMat(plantRend, plantsMats[0]);
                foreach (GameObject painting in paintingsPhase1)
                {
                    painting.SetActive(true);
                }
                ChangeLights(lights, colors[lightsInd]);
                break;
            case 3:
                plantRend.materials = SwitchPlantMat(plantRend, plantsMats[1]);
                foreach (GameObject painting in paintingsPhase2)
                {
                    painting.SetActive(true);
                }
                ChangeLights(lights, colors[lightsInd]);
                break;
            case 4:
                foreach (GameObject painting in paintingsPhase3)
                {
                    painting.SetActive(true);
                }
                plantRend.materials = SwitchPlantMat(plantRend, plantsMats[2]);
                
                break;
            case 5:
                foreach (GameObject painting in paintingsPhase4)
                {
                    painting.SetActive(true);
                }

                ChangeLights(lights, colors[lightsInd]);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            canExit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            canExit = false;
    }
    
    private Material[] SwitchPlantMat(Renderer rend, Material newMat)
    {
        Material[] newMats = new Material[rend.materials.Length];
        newMats[0] = rend.materials[0];
        newMats[1] = newMat;
        return newMats;
    }
    
    private bool CanSlideForward()
    {
        return Time.time - lastTimeChecked > waitTime;
    }

    private GameObject[] ChangeLights(GameObject[] lightsArr, Color32 colNew)
    {
        foreach (GameObject light in lightsArr)
            light.GetComponent<Light>().color = colNew;

        return lightsArr;
    }
}
