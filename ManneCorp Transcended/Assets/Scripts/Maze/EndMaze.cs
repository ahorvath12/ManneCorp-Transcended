using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMaze : MonoBehaviour
{
    public GameObject player, maze, house, lines, door;

    private float waitTime = 5f, lastTimeChecked;
    private bool canEnd, sayLine;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnd && HasTimePassed())
        {
            player.GetComponent<FadeToBlack>().AbruptAppear();
            
            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;
            maze.SetActive(false);
            house.GetComponent<HideHouse>().Return();
            canEnd = false;
            sayLine = true;
            door.GetComponent<LeaveHouse>().canEnd = true;
            lastTimeChecked = Time.time;
        }

        if (sayLine && HasTimePassed())
        {
            lines.GetComponent<DetectiveVoiceManager>().SayLine(8);
            sayLine = false;
        }
    }

    public void End()
    {
        lastTimeChecked = Time.time;
        canEnd = true;
    }

    private bool HasTimePassed()
    {
        return Time.time - lastTimeChecked > waitTime;
    }
}
 