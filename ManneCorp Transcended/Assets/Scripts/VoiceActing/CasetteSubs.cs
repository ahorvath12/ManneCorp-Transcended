using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasetteSubs : MonoBehaviour
{
    public GameObject[] subs;
    public bool show;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && show == true)
        {
            HideText(index);
            show = false;
        }
    }

    public void ShowText(int i)
    {
        index = i;
        subs[index].SetActive(true);
        show = true;
    }

    public void HideText(int i)
    {
        subs[i].SetActive(false);
    }
}
