using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineEnd : MonoBehaviour
{
    public int sceneNum;

    private AudioSource audioSource;
    private float waitTime = 1.5f, lastTimeChecked;
    private bool canLoad;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canLoad && !audioSource.isPlaying)
        {
            lastTimeChecked = Time.time;
            canLoad = true;
        }
        if (canLoad && WaitForTime())
            SceneManager.LoadScene(sceneNum);
    }

    private bool WaitForTime()
    {
        Debug.Log(Time.time - lastTimeChecked > waitTime);
        return Time.time - lastTimeChecked > waitTime;
    }
    
}
