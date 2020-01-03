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

    public Transform selection;
    public Transform theDestination;

    private Vector3 originalPos;
    public Quaternion originalRot;

    public bool isObjectPickUp;

    public DisplayObject displayObject;

    [Header("Cursors")]
    public Image pickUpCursor;
    public Image interactCursor;

    public Animator anim;

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
            }

            if (objectHit.CompareTag(interactableTag))
            {
                selection = objectHit;

                InteractWithObject(selection);
            }

            if (objectHit.CompareTag(animationTag))
            {
                selection = objectHit;

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
        interactCursor.enabled = true;

        if (Input.GetMouseButtonDown(0))
        {
            displayObject.DisplayObjectInfo(selection);
        }
    }

    void ObjectWithAnimation(Transform selection)
    {
        interactCursor.enabled = true;

        anim = selection.GetComponent<Animator>();

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Active");
        }
    }

    void ObjectToInventory(Transform selection)
    {
        PickingUpObject(selection);

        if (Input.GetKeyDown(KeyCode.I))
        {
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
