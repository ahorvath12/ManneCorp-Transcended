using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject image;

    private PickUpItem pickUp;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GetComponent<PickUpItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m") && pickUp.pickUp)
        {
            image.GetComponent<Image>().enabled = !image.GetComponent<Image>().enabled;
        }
    }
}
