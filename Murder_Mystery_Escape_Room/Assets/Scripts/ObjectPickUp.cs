using UnityEngine;
using UnityEngine.UI;

public class ObjectPickUp : MonoBehaviour
{
    [Header("Object Tags")]
    public string objectTag = "Object";
    public string interactableTag = "Interact";
    public string animationTag = "Animation";
    public string objectToInventoryTag = "Inventory";

    public float maxDistance;
    public int mask = 1 << 8;

    //public string objectRequiredToPass;

    public Transform selection;
    public Transform theDestination;

    private Vector3 originalPos;
    private Quaternion originalRot;

    public bool isObjectPickUp;

    public DisplayObject displayObject;

    [Header("Cursors")]
    public Image pickUpCursor;
    public Image interactCursor;

    public Animator anim;
    public AudioSource aSource;
    public bool audioState;

    public bool isRequirementsMet;

    public Transform selectedObject;
    public Clues clues;

    void Start()
    {
        isObjectPickUp = false;

        displayObject.GetComponent<DisplayObject>();

        audioState = true;

        if(aSource != null)
        {
            return;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        selection = null;

        // Sends out a raycast on a given layer mask
        if (Physics.Raycast(ray, out hit, maxDistance, mask))
        {
            // Gets the current objects transform and assigns to a Transform variable
            Transform objectHit = hit.transform;

            // If the objects tag = to a pickable object
            if (objectHit.CompareTag(objectTag))
            {
                selection = objectHit;

                PickingUpObject(selection);
            } else
            {
                pickUpCursor.enabled = false;
            }

            // If the objects tag = to an interactable object
            if (objectHit.CompareTag(interactableTag))
            {
                selection = objectHit;

                interactCursor.enabled = true;

                InteractWithObject(selection);
            }
            else
            {
                interactCursor.enabled = false;
            }

            // If the objects tag = to an animation object
            if (objectHit.CompareTag(animationTag))
            {
                selection = objectHit;

                interactCursor.enabled = true;

                //GetAudioComp(selection);

                ObjectWithAnimation(selection);
            }

            // If the objects tag = to an object that can be put into the inventory
            if (objectHit.CompareTag(objectToInventoryTag))
            {
                selection = objectHit;

                ObjectToInventory(selection);
            }
        }
        else
        {
            pickUpCursor.enabled = false;
            interactCursor.enabled = false;
            displayObject.RemoveObjectInfo(selection);
        }
    }

    // Picking up an object
    void PickingUpObject(Transform selection)
    {
        // When the object is picked up the cursor disappears 
        if (!isObjectPickUp)
            pickUpCursor.enabled = true;

        // If the object has already been picked up then player can put down the object
        if (isObjectPickUp)
        {  
            if (Input.GetMouseButtonDown(1))
            {
                OnDropObject(selection);
            }
            return;
        }
        else
        {
            // Picking up the object
            if (Input.GetMouseButtonDown(0))
            {
                OnHoldObject(selection);
            }
        }
    }

    // Displays an object that can't be picked up information
    void InteractWithObject(Transform selection)
    {
        if (Input.GetMouseButtonDown(0))
        {
            displayObject.DisplayObjectInfo(selection);
        } 
        else if (Input.GetMouseButtonDown(1))
        {
            displayObject.RemoveObjectInfo(selection);
        }
    }

    // If an object has an animation attached
    void ObjectWithAnimation(Transform selection)
    {
        // Gets the animator attached to object
        anim = selection.GetComponent<Animator>();
        
        //aSource2 = selection.GetComponent<AudioSource>();

        selectedObject = selection;

        if (Input.GetMouseButtonDown(0) && !selection.GetComponent<Object>().hasPlayed)
        {
            displayObject.DisplayObjectInfo(selection);

            if (selectedObject.GetComponent<Object>().isObjectInteractable)
            {
                aSource = selection.GetComponent<Object>().firstAudioSource;

                anim.SetTrigger("Active");
                aSource.Play();
                selection.GetComponent<Object>().hasPlayed = true;

            }
        }
         else if (Input.GetMouseButtonDown(0) && selection.GetComponent<Object>().hasPlayed)
        {
            displayObject.DisplayObjectInfo(selection);

            if (selectedObject.GetComponent<Object>().isObjectInteractable)
            {
                aSource = selection.GetComponent<Object>().secondAudioSource;

                anim.SetTrigger("Deactive");
                aSource.Play();
            }
            selection.GetComponent<Object>().hasPlayed = false;
        }
    }

    // If an object can be put into the players inventory
    void ObjectToInventory(Transform selection)
    {
        PickingUpObject(selection);

        if (Input.GetKeyDown(KeyCode.I))
        {
            // Cues sound
            FindObjectOfType<AudioManager>().Play("PickingUpObject");
            
            // Checks the clue
            clues.CheckClue(selection.GetComponent<Object>().clueInt);

            isRequirementsMet = true;
            Destroy(selection.gameObject);
            isObjectPickUp = false;
        }
    }

    // Hold the object
    void OnHoldObject(Transform selection)
    {
        pickUpCursor.enabled = false;

        isObjectPickUp = true;

        // Sets the objects original position and rotation 
        originalPos = new Vector3(selection.transform.position.x, selection.transform.position.y, selection.transform.position.z);
        originalRot = new Quaternion(selection.transform.rotation.x, selection.transform.rotation.y, selection.transform.rotation.z, selection.transform.rotation.w);

        // Sets the new objects postion 
        selection.position = theDestination.transform.position;
       
        // Displays the objects information
        displayObject.DisplayObjectInfo(selection);
    }

    // Dropping the object
    void OnDropObject(Transform selection)
    {
        isObjectPickUp = false;

        // Sets the original position and rotation of the object
        selection.transform.position = originalPos;
        selection.transform.rotation = originalRot;

        // Removes the object information
        displayObject.RemoveObjectInfo(selection);
    }
}
