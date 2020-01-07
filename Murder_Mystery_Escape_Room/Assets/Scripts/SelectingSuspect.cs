using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingSuspect : MonoBehaviour
{
    public Button suspect1, suspect2, suspect3, suspect4;
    public Text suspectName1, suspectName2, suspectName3, suspectName4;

    public Button suspect1Arrest, suspect2Arrest, suspect3Arrest, suspect4Arrest;

    public GameObject suspect1Info, suspect2Info, suspect3Info, suspect4Info;

    public void Suspect1()
    {
        suspect1Info.SetActive(true);
    }

    public void Suspect2()
    {
        suspect2Info.SetActive(true);
    }

    public void Suspect3()
    {
        suspect3Info.SetActive(true);
    }

    public void Suspect4()
    {
        suspect4Info.SetActive(true);
    }

    public void SuspectArrest()
    {
        GameManager.instance.WrongSuspectLose();
    }

    public void CorrectSuspectArrest()
    {
        GameManager.instance.GameWin();
    }

    void Update()
    {
        if (suspect1Info.activeInHierarchy || suspect2Info.activeInHierarchy ||
            suspect3Info.activeInHierarchy || suspect4Info.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(1))
            {
                suspect1Info.SetActive(false);
                suspect2Info.SetActive(false);
                suspect3Info.SetActive(false);
                suspect4Info.SetActive(false);
            }
        }
    }

    //public Button[] spts;

    //void SuspectSelect()
    //{
    //    for (int i = 0; i < spts.Length; i++)
    //    {
    //        spts[i].onClick.AddListener(TaskOnClick);


    //    }
    //}

    //void TaskOnClick()
    //{

    //}
}
