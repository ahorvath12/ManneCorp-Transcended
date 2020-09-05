using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackPanel;

    private Image panel;
    private bool reappear;
    private int step = 1, alpha;

    // Start is called before the first frame update
    void Start()
    {
        panel = blackPanel.GetComponent<Image>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha > 0)
        {
            alpha -= step;
            Debug.Log(alpha);
            panel.color = new Color32(0, 0, 0, (byte)alpha);
            Debug.Log("Screen disapepar");
        }

    }

    public void AbruptAppear()
    {
        Debug.Log("screen appear)");
        panel.color = new Color32(0, 0, 0, 255);
        alpha = 255;
        Debug.Log("Appear");
        reappear = true;
    }

    
}
