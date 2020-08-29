using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarItem : MonoBehaviour
{
    public string name;
    public GameObject altar;

    private PickUpItem pickUp;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GetComponent<PickUpItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.pickUp)
        {
            switch (name)
            {
                case "book":
                    altar.GetComponent<PlaceItemOnAltar>().HasBook();
                    break;
                case "blood":
                    altar.GetComponent<PlaceItemOnAltar>().HasBlood();
                    break;
                case "flesh":
                    altar.GetComponent<PlaceItemOnAltar>().HasFlesh();
                    break;
            }
        }
    }
}
