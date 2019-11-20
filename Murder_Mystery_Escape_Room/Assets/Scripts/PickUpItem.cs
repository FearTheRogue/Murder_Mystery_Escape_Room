using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Camera fps;
    public Transform theDest;
    public Text nameText, DescText;

    public string nameOfObject, DescOfObject;

    float maxDistance = 10f;

    void OnMouseDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(fps.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = true;

            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Object Destination").transform;

            nameText.text = "Name: " + nameOfObject;
            DescText.text = "Description: " + DescOfObject;
        }
    }

    void OnMouseUp()
    {
        this.transform.parent = null;

        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        //GetComponent<BoxCollider>().enabled = true;

        nameText.text = "";
        DescText.text = "";
    }

    void OnMouseOver()
    {
        RaycastHit hit;

        if (Physics.Raycast(fps.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance)) 
        { 
            Debug.DrawRay(fps.transform.position, fps.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
        //Debug.Log("Nope");
    }

    void OnMouseExit() 
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    //void FixedUpdate()
    //{
    //    RaycastHit hit;

    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        if (Physics.Raycast(theDest.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
    //        {
    //            print("Found an object - distance: " + hit.distance);
    //            Debug.DrawRay(theDest.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
    //        }
    //    }
    //}
}
