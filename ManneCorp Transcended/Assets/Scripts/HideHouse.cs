using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHouse : MonoBehaviour
{

    private Vector3 origin, moveTo;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        moveTo = new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        transform.position = moveTo;
    }

    public void Return()
    {
        transform.position = origin;
    }
}
