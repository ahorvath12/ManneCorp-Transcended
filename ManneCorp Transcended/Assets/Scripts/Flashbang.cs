using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashbang : MonoBehaviour
{
    public bool flash;

    private Image panel;
    private float waitTime = 4 , lastTimeChecked;
    private bool fade;

    private int step = 1, alpha;

    // Start is called before the first frame update
    void Start()
    {
        lastTimeChecked = Time.time;
        panel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha > 0)
        {
            //panel.CrossFadeAlpha(0, 4f, false);
            alpha -= step;
            Debug.Log(alpha);
            panel.color = new Color32(255, 255, 255, (byte) alpha);
            flash = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && HasTimePassed())
        {
            Appear();
            fade = true;
            alpha = 255;
        }
    }

    public bool HasTimePassed()
    {
        return Time.time - lastTimeChecked > waitTime;
    }

    private void Appear()
    {
        Debug.Log("flash");
        lastTimeChecked = Time.time;
        panel.color = new Color32(255, 255, 255, 255);
        GetComponent<AudioSource>().Play();
        fade = true;
        flash = true;
    }
}
