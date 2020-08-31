using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaveHouse : MonoBehaviour
{
    public GameObject player, pressE, notLeave;
    public bool canEnd;

    private bool isNear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("e")) { 

            if (canEnd)
            {
                pressE.GetComponent<Text>().enabled = false;
                SceneManager.LoadScene("EndScene");
            }
            else
            {
                notLeave.GetComponent<Text>().enabled = true;
                pressE.GetComponent<Text>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isNear = true;
        pressE.GetComponent<Text>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
        pressE.GetComponent<Text>().enabled = false;
        notLeave.GetComponent<Text>().enabled = false;
    }
}
