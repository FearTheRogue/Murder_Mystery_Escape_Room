using UnityEngine;

public class ZoomObjects : MonoBehaviour
{
    public float minFOV;
    public float maxFOV;
    public float sensitivity;

    public ObjectPickUp ObjectPickUp;

    void Start()
    {
        maxFOV = Camera.main.fieldOfView;
    }

    void Update()
    {
        if (ObjectPickUp.isObjectPickUp)
        {
            float fov = Camera.main.fieldOfView;
            fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFOV, maxFOV);
            Camera.main.fieldOfView = fov;
        }
        else
        {
            Camera.main.fieldOfView = maxFOV;
        }
    }
}
