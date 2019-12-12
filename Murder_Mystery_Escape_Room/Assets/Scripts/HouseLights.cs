using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLights : MonoBehaviour
{
    public Material lightsOn;

    void Start()
    {
        lightsOn = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            lightsOn.SetColor("_EmissionColor", Color.black);
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lightsOn.SetColor("_EmissionColor", Color.yellow);
        }

    }
}
