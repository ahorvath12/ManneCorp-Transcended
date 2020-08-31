using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLoopingRoom : MonoBehaviour
{
    public GameObject player, placeholder;
    public string roomTag;
    public GameObject room;
    public GameObject text, pressE, blackPanel;
    public bool end;
    public GameObject[] revealWithTag;

    private float waitTime = 3f, lastTimeChecked;
    bool fade, near;

    // Start is called before the first frame update
    void Start()
    {
        pressE = GameObject.Find("PressE");
    }

    // Update is called once per frame
    void Update()
    {
        if (near)
        {
            if (end && Input.GetKeyDown("e"))
            {
                foreach (GameObject go in revealWithTag)
                {
                    go.SetActive(true);
                    Debug.Log(go.name);
                }
                pressE.GetComponent<Text>().enabled = false;
                Debug.Log("set room unactive");
                player.GetComponent<FadeToBlack>().AbruptAppear();
                player.transform.position = placeholder.transform.position;
                player.transform.rotation = placeholder.transform.rotation;
                GameObject.Find("house").GetComponent<HideHouse>().Return();
                GameObject.Find("KidsRoomPlaceholder").GetComponent<CloseLoopingRoom>().hide = true;

            }
            else if (!end && Input.GetKeyDown("e"))
            {
                pressE.GetComponent<Text>().enabled = false;
                text.GetComponent<Text>().enabled = true;
                lastTimeChecked = Time.time;
                fade = true;
            }
        }
        
        if (fade && WaitToFade())
        {
            fade = false;
            text.GetComponent<Text>().enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        near = true;
        pressE.GetComponent<Text>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        near = false;
        pressE.GetComponent<Text>().enabled = false;
    }

    private bool WaitToFade()
    {
        return Time.time - lastTimeChecked > waitTime;
    }
}
