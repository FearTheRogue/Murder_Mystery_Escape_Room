using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLog : MonoBehaviour
{
    public Animator logAnim;
    public Image pickUpCursor;

    bool animationHasPlayed;

    void Start()
    {
        logAnim = gameObject.GetComponent<Animator>();
        pickUpCursor.GetComponent<Image>();

        animationHasPlayed = false;
    }

    private void OnMouseDown()
    {
        logAnim.SetTrigger("Active");

        animationHasPlayed = true;
    }

    private void OnMouseOver()
    {
        if(!animationHasPlayed)
        pickUpCursor.enabled = true;
        else
        {
            return;
        }
    }

    private void OnMouseExit()
    {
        if(!animationHasPlayed)
        pickUpCursor.enabled = false;
        else
        {
            return;
        }
    }
}
