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

    public float maxDistance = 10f;

   public IsPlayerMoving playerMoving;

    public bool isMoving;

    public Image pickUpCursor;

    private void Start()
    {
        isMoving = playerMoving.GetComponent<IsPlayerMoving>().isPlayerMoving;

        pickUpCursor.GetComponent<Image>();
    }

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

            playerMoving.GetComponent<IsPlayerMoving>().isPlayerMoving = false;
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

        playerMoving.GetComponent<IsPlayerMoving>().isPlayerMoving = true;
    }

    void OnMouseOver()
    {
        RaycastHit hit;

        if (Physics.Raycast(fps.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance)) 
        { 
            Debug.DrawRay(fps.transform.position, fps.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            GetComponent<MeshRenderer>().material.color = Color.red;
            pickUpCursor.enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
            pickUpCursor.enabled = false;
        }
        //Debug.Log("Nope");
    }

    void OnMouseExit() 
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
        pickUpCursor.enabled = false;
    }
}
