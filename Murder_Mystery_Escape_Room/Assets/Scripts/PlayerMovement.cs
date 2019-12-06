using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public IsPlayerMoving playerMoving;

    public bool isPlayerMoving;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isPlayerMoving = playerMoving.GetComponent<IsPlayerMoving>().isPlayerMoving;

        if (playerMoving.GetComponent<IsPlayerMoving>().isPlayerMoving)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
