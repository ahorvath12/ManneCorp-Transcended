using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToMannequin : MonoBehaviour
{
    public GameObject lines;
    public GameObject player, meshGO;

    private Renderer rend;
    private bool hasSaidLine;

    // Start is called before the first frame update
    void Start()
    {
        rend = meshGO.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSaidLine && rend.isVisible && Vector3.Distance(transform.position, player.transform.position) <= 10)
        {
            lines.GetComponent<DetectiveVoiceManager>().SayLine(4);
            hasSaidLine = true;
        }
    }
}
