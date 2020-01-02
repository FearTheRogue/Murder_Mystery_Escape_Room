using UnityEngine;
using UnityEngine.UI;

public class ObjectPickUp : MonoBehaviour
{
    public string objectTag = "Object";

    public float maxDistance;
    public int mask = 1 << 8;

    private Transform selection;
    public Transform theDestination;

    private Vector3 originalPos;
    public Quaternion originalRot;

    public bool isObjectPickUp;

    public DisplayObject displayObject;
    //public Object _object;

    public Image pickUpCursor;

    void Start()
    {
        isObjectPickUp = false;

        displayObject.GetComponent<DisplayObject>();
        //_object.GetComponent<Object>();
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
        }
        else
        {
            pickUpCursor.enabled = false;
        }
    }

    void OnHoldObject(Transform selection)
    {
        pickUpCursor.enabled = false;

        isObjectPickUp = true;

        originalPos = new Vector3(selection.transform.position.x, selection.transform.position.y, selection.transform.position.z);
        //originalRot = transform.localRotation;
        originalRot = new Quaternion(selection.transform.rotation.x, selection.transform.rotation.y, selection.transform.rotation.z,0);

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
