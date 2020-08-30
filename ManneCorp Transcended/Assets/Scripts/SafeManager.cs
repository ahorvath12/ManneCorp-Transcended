using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SafeManager : MonoBehaviour
{
    public GameObject player, safeCodeUI, codeText, safeNote, pressE, cassette;
    public bool locked;
    public string code;

    private Animator anim;
    private bool isNear, hasReadNote, openCode, pressedButton, opened;
    private string inputCode = "";

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("e") && !opened){
            player.GetComponent<FirstPersonController>().enabled = !player.GetComponent<FirstPersonController>().enabled;
            
            pressE.GetComponent<Text>().enabled = false;

            pressedButton = !pressedButton;

            if (openCode)
            {
                safeCodeUI.SetActive(pressedButton);
            }

            if (hasReadNote)
            {
                safeNote.SetActive(false);
                openCode = true;
            }
            else
            {
                safeNote.SetActive(true);
                hasReadNote = true;
                GameObject.Find("Lines").GetComponent<DetectiveVoiceManager>().SayLine(1);
            }
            
        }

        if (pressedButton)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log("added 0");
                AddNumToCode("0");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AddNumToCode("1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                AddNumToCode("2");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                AddNumToCode("3");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                AddNumToCode("4");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                AddNumToCode("5");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                AddNumToCode("6");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                AddNumToCode("7");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                AddNumToCode("8");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                AddNumToCode("9");
            }
        }
        else if (!pressedButton && openCode)
        {
            inputCode = "";
            codeText.GetComponent<Text>().text = "";
        }

        if(inputCode == code)
        {
            anim.SetTrigger("open");
            cassette.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = true;
            safeCodeUI.SetActive(false);
            safeCodeUI = null;
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SelectedFlash>().enabled = false;
            }
            GetComponent<SafeManager>().enabled = false;
        }
        else if (inputCode.Length > 4)
        {
            inputCode = "";
            codeText.GetComponent<Text>().text = "";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNear = true;
            pressE.GetComponent<Text>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNear = false;
            pressE.GetComponent<Text>().enabled = false;
        }
    }

    private void AddNumToCode(string num)
    {
        codeText.GetComponent<Text>().text += num + " ";
        inputCode += num;
        Debug.Log(inputCode);
    }
}
