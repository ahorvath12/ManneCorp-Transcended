using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public int redCol = 250, greenCol = 250, blueCol;


    GameObject selectedObject;
    bool lookingAtObject = false;
    bool flashingIn = true;
    bool startedFlashing = false;


    // Update is called once per frame
    void Update()
    {
        if (lookingAtObject)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte) redCol, (byte) greenCol, (byte) blueCol, 25);
        }
    }

    private void OnTriggerEnter()
    {
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        lookingAtObject = true;
        if (!startedFlashing)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
    }

    private void OnTriggerExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject)
        {
            yield return new WaitForSeconds(0.15f);
            if(flashingIn)
            {
                if (redCol <= 127)
                    flashingIn = false;
                else
                {
                    redCol -= 25;
                    greenCol -= 25;
                }
            }
            else
            {
                if (redCol >= 250)
                    flashingIn = true;
                else
                {
                    redCol += 25;
                    greenCol += 25;
                }
            }
        }
    }
}
