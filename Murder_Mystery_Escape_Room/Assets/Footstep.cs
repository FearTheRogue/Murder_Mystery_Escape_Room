using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    CharacterController cc;

    PlayerMovement playerMovement;

    public AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isPlayerMoving)
        {
            audioS.volume = Random.Range(0.8f, 1f);
            audioS.pitch = Random.Range(0.8f, 1.1f);
            audioS.loop = true;

            audioS.Play();
        }
    }
}
