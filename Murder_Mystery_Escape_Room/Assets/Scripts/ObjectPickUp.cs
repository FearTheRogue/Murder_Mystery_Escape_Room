using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    public string objectTag = "Object";

    public float maxDistance;

    private Transform selection;
    public Transform theDestination;

    private Vector3 originalPos;
    private Quaternion originalRot;

    public bool isObjectPickUp;

    public DisplayObject displayObject;

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

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag(objectTag))
            {
                selection = objectHit;
                
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
    }

    void OnHoldObject(Transform selection)
    {
        isObjectPickUp = true;

        originalPos = new Vector3(selection.transform.position.x, selection.transform.position.y, selection.transform.position.z);
        originalRot = transform.rotation;

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
