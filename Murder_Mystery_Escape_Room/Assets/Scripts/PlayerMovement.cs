using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    //public IsPlayerMoving playerMoving;

    public bool isPlayerMoving;

    public ObjectPickUp objectPickUp;

    public Vector3 move;
    public Vector3 velocity;
    public bool isGrounded;

    public Transform groundCheck;
    public float grounndDistance = 0.4f;
    public LayerMask groundMask;

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
            isGrounded = Physics.CheckSphere(groundCheck.position, grounndDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

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
