﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayObject : MonoBehaviour
{
    public Text nameOfObjectText, descOfObjectText;

    public Image textBG;

    void Start()
    {
        nameOfObjectText.enabled = false;
        descOfObjectText.enabled = false;

        textBG.enabled = false;
    }

    public void DisplayObjectInfo(Transform selection)
    {
        nameOfObjectText.enabled = true;
        descOfObjectText.enabled = true;

        textBG.enabled = true;
        string name = selection.GetComponent<Object>().nameOfObject;
        string desc = selection.GetComponent<Object>().DescOfObject;

        nameOfObjectText.text = name;
        descOfObjectText.text = desc;
    }

    public void RemoveObjectInfo(Transform selection)
    {
        textBG.enabled = false;
        nameOfObjectText.text = "";
        descOfObjectText.text = "";
    }

}
