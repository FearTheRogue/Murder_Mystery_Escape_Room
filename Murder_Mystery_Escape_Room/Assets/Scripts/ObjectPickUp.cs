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

    public bool isRequirementsMet;

    public Transform selectedObject;
    public Clues clues;

    void Start()
    {
        isObjectPickUp = false;

        displayObject.GetComponent<DisplayObject>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        selection = null;

        if (Physics.Raycast(ray, out hit, maxDistance, mask))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag(objectTag))
            {
                selection = objectHit;

                PickingUpObject(selection);
            } else
            {
                pickUpCursor.enabled = false;
            }

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

            if (objectHit.CompareTag(animationTag))
            {
                selection = objectHit;

                interactCursor.enabled = true;

                ObjectWithAnimation(selection);
            }

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
        }
    }

    void PickingUpObject(Transform selection)
    {
         if (!isObjectPickUp)
            pickUpCursor.enabled = true;

        if (Input.GetMouseButtonDown(1))
        {
            OnDropObject(selection);
        }

        if (isObjectPickUp)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnHoldObject(selection);
            }
        }
    }

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

    void ObjectWithAnimation(Transform selection)
    {
        anim = selection.GetComponent<Animator>();

        selectedObject = selection;

        if (Input.GetMouseButtonDown(0))
        {
            displayObject.DisplayObjectInfo(selection);

            if (selectedObject.GetComponent<Object>().isObjectInteractable)
            {
                anim.SetTrigger("Active");
            }
         //   if (isRequirementsMet)
           // { 
              //  anim.SetTrigger("Active");
            //}
        }       
    }

    void ObjectToInventory(Transform selection)
    {
        PickingUpObject(selection);

        if (Input.GetKeyDown(KeyCode.I))
        {
            clues.CheckClue(selection.GetComponent<Object>().clueInt);

            isRequirementsMet = true;
            Destroy(selection.gameObject);
            isObjectPickUp = false;
        }
    }

    void OnHoldObject(Transform selection)
    {
        pickUpCursor.enabled = false;

        isObjectPickUp = true;

        originalPos = new Vector3(selection.transform.position.x, selection.transform.position.y, selection.transform.position.z);
        originalRot = new Quaternion(selection.transform.rotation.x, selection.transform.rotation.y, selection.transform.rotation.z, selection.transform.rotation.w);

        selection.position = theDestination.transform.position;
        
        displayObject.DisplayObjectInfo(selection);
    }

    void OnDropObject(Transform selection)
    {
        isObjectPickUp = false;

        selection.transform.position = originalPos;
        selection.transform.rotation = originalRot;

        displayObject.RemoveObjectInfo(selection);
    }

    //Come back to it later
    void RotateObject(Transform selection)
    {
        Debug.Log("This is being calledfdjksj");

        //float rotationSpeed = 500f;

        //float rotX = Input.Get * Time.deltaTime * Mathf.Deg2Rad;
        //float rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * Mathf.Deg2Rad;

        //selection.transform.Rotate(Vector3.up, -rotX);
        //selection.transform.Rotate(Vector3.right, rotY);
    }
}
