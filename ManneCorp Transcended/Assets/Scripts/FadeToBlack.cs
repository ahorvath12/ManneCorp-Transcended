using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackPanel;

    private Image panel;
    private bool reappear;

    // Start is called before the first frame update
    void Start()
    {
        panel = blackPanel.GetComponent<Image>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (reappear && panel.color.a > 0)
        {
            panel.GetComponent<Image>().CrossFadeAlpha(0, 4f, false);
            reappear = false;
        }

    }

    public void AbruptAppear()
    {
        panel.color = new Color32(0, 0, 0, 255);
        Debug.Log("Appear");
        reappear = true;
    }

    
}
