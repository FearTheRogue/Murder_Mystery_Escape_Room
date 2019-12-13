using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayObject : MonoBehaviour
{
    public Text nameOfObjectText, descOfObjectText;

    public void DisplayObjectInfo(Transform selection)
    {
        string name = selection.GetComponent<Object>().nameOfObject;
        string desc = selection.GetComponent<Object>().DescOfObject;

        nameOfObjectText.text = name;
        descOfObjectText.text = desc;
    }

    public void RemoveObjectInfo(Transform selection)
    {
        nameOfObjectText.text = "";
        descOfObjectText.text = "";
    }

}
