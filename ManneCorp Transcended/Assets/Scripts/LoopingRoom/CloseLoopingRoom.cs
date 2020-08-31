using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLoopingRoom : MonoBehaviour
{
    public GameObject room;
    public bool hide;

    private void Update()
    {
        if (hide)
        {
            HideRoom();
        }
    }

    //this is what happens when the game breaks the night before the deadline
    public void HideRoom()
    {
        room.SetActive(false);
    }
}
