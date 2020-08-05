using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour
{
    Light lt;
    float originalRange;
    bool canStart;

    [Space(10)]

    [Header("Light customization")]
    [Space(10)]
    //[SerializeField]
    //[Tooltip("The color of your light.")]
    //Color lightColor = Color.yellow;

    [SerializeField]
    [Tooltip("The min intensity of your light.")]
    float minIntensity = 8f;
    [SerializeField]
    [Tooltip("The max intensity of your light.")]
    float maxIntensity = 3f;
    [SerializeField]
    [Tooltip("The minimal range of your light (radius).")]
    float minRange = 79f;
    [SerializeField]
    [Tooltip("The maximum range of your light (radius).")]
    float maxRange = 100f;

    float timeSwitch, lastTimeChecked;

    void Start()
    {
        lt = GetComponent<Light>();
        timeSwitch = Random.Range(0.05f, 0.2f);
        lastTimeChecked = Time.time;
    }
    void FixedUpdate()
    {
        //lightColor = lt.color;
        if (canStart && CanSwitch())
        {
            lt.intensity = Random.Range(minIntensity, maxIntensity);
            lt.range = Random.Range(minRange, maxRange);
            //lt.color = lightColor;
            lastTimeChecked = Time.time;
        }
        
    }

    public void StartFlickering(bool start)
    {
        canStart = start;
    }

    private bool CanSwitch()
    {
        return Time.time - lastTimeChecked > timeSwitch;
    }
}