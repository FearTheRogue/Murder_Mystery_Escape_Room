using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObjects : MonoBehaviour
{
    //public PickUpItem[] pickUp;
    public Camera fps;
    public Transform theDest;
    public float maxDistance;

    void Start()
    {
        //pickUp = FindObjectsOfType<PickUpItem>();
    }

    public void LookAtObject()
    {

    }

    public void HoldObject()
    {
        //RaycastHit hit;

        //for (int i = 0; i < pickUp.Length; i++)
        //{
        //    if (Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, maxDistance))
        //    {
        //        pickUp[i].transform.position = theDest.position;
        //        pickUp[i].transform.parent = theDest;

        //        Debug.DrawRay(fps.transform.position, fps.transform.forward * hit.distance, Color.blue);
        //    }
        //}
        Debug.Log("I am holding an object");

    }

    void Update()
    { 
        //RaycastHit hit;

        //foreach (PickUpItem item in pickUp)
        //{
        //    if(Physics.Raycast(fps.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
        //    {
        //        Debug.Log(item.name);
        //    }
        //}

        //for (int i = 0; i < pickUp.Length; i++)
        //{
        //    if (Physics.Raycast(fps.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
        //    {
        //        Debug.Log("You're look at " + pickUp[i].name);
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            HoldObject();
        }


        //Debug.DrawRay(fps.transform.position, fps.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
    }
}
