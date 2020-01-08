using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    //public IsPlayerMoving playerMoving;

    public bool isPlayerMoving;

    public ObjectPickUp objectPickUp;

    public Vector3 move;

    public Vector3 isNotMoving;

    public AudioSource audioS;

    private void Start()
    {
        isNotMoving = new Vector3(0f, 0f, 0f);
        audioS.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!objectPickUp.GetComponent<ObjectPickUp>().isObjectPickUp)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (move == isNotMoving)
            {
                isPlayerMoving = false;
            }

            if (move.z > 0f || move.z < 0f || move.x > 0f || move.x < 0f)
            {
                isPlayerMoving = true;
            }
        }
    }
}
