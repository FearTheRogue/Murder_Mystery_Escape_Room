using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Transform theDest;
    public Text nameText, DescText;

    public string nameOfObject, DescOfObject;

    float maxDistance = 10f;

    void OnMouseDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.localPosition, out hit, maxDistance))
        {
            Debug.Log("Object: " + this.name);

            //GetComponent<BoxCollider>().enabled = false;
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Nope");
    }

    //void FixedUpdate()
    //{
    //    RaycastHit hit; 

    //    if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Object: " + hit.point);
    //    }
    //}
}
