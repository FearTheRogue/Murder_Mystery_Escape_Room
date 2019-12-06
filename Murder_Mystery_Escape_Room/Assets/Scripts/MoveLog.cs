using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLog : MonoBehaviour
{
    public Animator logAnim;
    public Image pickUpCursor;

    void Start()
    {
        logAnim = gameObject.GetComponent<Animator>();
        pickUpCursor.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        logAnim.SetTrigger("Active");
    }

    private void OnMouseOver()
    {
        pickUpCursor.enabled = true;
    }

    private void OnMouseExit()
    {
        pickUpCursor.enabled = false;
    }
}
