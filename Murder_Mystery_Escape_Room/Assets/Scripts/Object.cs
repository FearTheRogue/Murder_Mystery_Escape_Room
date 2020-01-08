using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    //public Text nameText, DescText;

    [Header("Name and Description of Object")]
    public string nameOfObject;
    public string DescOfObject;

    //public IsPlayerMoving playerMoving;

    //public bool isMoving;

    [Header("Can the Object be Interacted with")]
    public bool isObjectInteractable;

    [Header("Only for Object that unlock clues")]
    public int clueInt;

    public AudioSource firstAudioSource;
    public AudioSource secondAudioSource;

    public bool hasPlayed;

    //public Image pickUpCursor;

    private void Start()
    {
        //isMoving = playerMoving.GetComponent<IsPlayerMoving>().isPlayerMoving;
        //if(pickUpCursor != null)
        //pickUpCursor.GetComponent<Image>();

        //originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
       // originalRot = transform.rotation;

    }

    /* void OnMouseDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(fps.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
        {
            //GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<Rigidbody>().freezeRotation = true;

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

        //GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<Rigidbody>().freezeRotation = false;
        //GetComponent<BoxCollider>().enabled = true;

        nameText.text = "";
        DescText.text = "";

        playerMoving.GetComponent<IsPlayerMoving>().isPlayerMoving = true;

        gameObject.transform.position = originalPos;
        gameObject.transform.rotation = originalRot;
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
    } */

    void Update()
    {
       // RaycastHit hit;

       // Physics.Raycast(fps.transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance);

        //Debug.DrawRay(fps.transform.position, fps.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    }
}
