using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class LoopingController : MonoBehaviour
{
    public GameObject player, otherDoor, placeholderStart, placeholder, placeholderEnd, changingPainting;
    public Material[] plantsMats;
    public GameObject[] dolls, lights, lightsFake, paintingsPhase1, paintingsPhase2, paintingsPhase3, paintingsPhase4;

    bool canExit, restart, startLoop, slideForward;
    int phase, lightsInd;
    float moveSpeed = 3f;
    float waitTime = 3.5f, lastTimeChecked;
    Renderer plantRend;
    Color32[] colors;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
            ChangeLights(lightsFake, colors[lightsInd]);
            
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
        //teleport
        if(startLoop && Vector3.Distance(player.transform.position, placeholderStart.transform.position) <= 0.005f)
        {
            phase++;
            player.transform.position = placeholder.transform.position;
            player.transform.rotation = placeholder.transform.rotation;
            startLoop = false;
            slideForward = true;
            otherDoor.GetComponent<Animator>().SetBool("open", true);
            otherDoor.GetComponent<AudioSource>().Play();
            lastTimeChecked = Time.time;

            if (phase == 2 || phase == 3)
                lightsInd++;
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
            otherDoor.GetComponent<AudioSource>().Play();
        }

        //change environment depending on phase
        switch (phase)
        {
            case 1:
                dolls[phase].SetActive(true);
                break;
            case 2:
                dolls[phase].SetActive(true);
                plantRend.materials = SwitchPlantMat(plantRend, plantsMats[0]);
                foreach (GameObject painting in paintingsPhase1)
                {
                    painting.SetActive(true);
                }
                ChangeLights(lights, colors[lightsInd]);
                break;
            case 3:
                dolls[phase].SetActive(true);
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
                dolls[phase-1].SetActive(true);
                for (int i = phase-2; i >= 0; i--)
                {
                    dolls[i].SetActive(false);
                }
                foreach (GameObject painting in paintingsPhase4)
                {
                    painting.SetActive(true);
                }
                ChangeLights(lights, colors[lightsInd]);
                GameObject.FindWithTag("SueDoll").GetComponent<EndLoopingRoom>().end = true;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            GameObject.Find("PressE").GetComponent<Text>().enabled = true;
            canExit = true;
        }
        if (phase == 0)
        {
            otherDoor.GetComponent<StartNextRoom>().FullyStartArea();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            GameObject.Find("PressE").GetComponent<Text>().enabled = false;
            canExit = false;
        }
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
