using UnityEngine;

public class SuspectPanel : MonoBehaviour
{
    public GameObject suspectPanel;

    public ObjectPickUp objectPick;

    // Start is called before the first frame update
    void Start()
    {
        objectPick.GetComponent<ObjectPickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!suspectPanel.activeInHierarchy)
            {
                objectPick.isObjectPickUp = true;
                suspectPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else if (suspectPanel.activeInHierarchy)
            {
                objectPick.isObjectPickUp = false;
                suspectPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }    
    }
}
