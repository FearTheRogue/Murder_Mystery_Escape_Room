using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLights : MonoBehaviour
{
    //public Material lightsOn;

    //void Start()
    //{
    //    lightsOn = GetComponent<Renderer>().material;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        lightsOn.SetColor("_EmissionColor", Color.black);
    //    } 
    //    else if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        lightsOn.SetColor("_EmissionColor", Color.yellow);
    //    }

    //}


    public Material lightOff;
    public Material lightOn;

    // Start is called before the first frame update
    void Update()
    {
        StartCoroutine(flicker());
    }

    // Update is called once per frame
    IEnumerator flicker()
    {
        float waitTime = Random.Range(10.0f, 50.0f);

        this.gameObject.SetActive(false);
        Debug.Log("no light");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Light");
  
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
    }
}
