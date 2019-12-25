using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingSuspect : MonoBehaviour
{
    public Button suspect1, suspect2, suspect3, suspect4;
    public Text suspectName1, suspectName2, suspectName3, suspectName4;

    public void Suspect1()
    {
        Debug.Log("You have chosen " + suspectName1.text + " to be the killer");
    }

    public void Suspect2()
    {
        Debug.Log("You have chosen " + suspectName2.text + " to be the killer");
    }

    public void Suspect3()
    {
        Debug.Log("You have chosen " + suspectName3.text + " to be the killer");
    }

    public void Suspect4()
    {
        Debug.Log("You have chosen " + suspectName4.text + " to be the killer");
    }

    public Button[] spts;

    void SuspectSelect()
    {
        for (int i = 0; i < spts.Length; i++)
        {
            spts[i].onClick.AddListener(TaskOnClick);

            
        }
    }

    void TaskOnClick()
    {

    }
}
