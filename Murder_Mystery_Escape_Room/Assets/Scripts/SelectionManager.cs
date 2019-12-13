using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private string selectableTag = "Selectable";

    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Material highlightMaterial;

    private Transform _selection;

    void Update()
    {
        if(_selection != null)
        {
            OnDeselect(_selection);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        _selection = null;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        if (_selection != null)
        {
            OnSelect(_selection);
        }
    }

    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = defaultMaterial;
        }
    }
    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = highlightMaterial;
        }
    }
}
