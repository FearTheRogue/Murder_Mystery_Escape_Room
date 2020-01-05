using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    public bool[] clueBools;

    public int[] clues;

    public GameObject[] gos;
    
    public void CheckClue(int clueName)
    {
        for (int i = 0; i < clues.Length; i++)
        {
            if (clueName == clues[i])
            {
                Debug.Log(clues[i]);

                clueBools[i] = true;

                gos[i].GetComponent<Object>().isObjectInteractable = true;
            }
        }
    }
}
