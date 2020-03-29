using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    // Start is called before the first frame update
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform grountCheck;
    public float groundDistance = 1f;

    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public void SetLocation(MazeCell cell)
    {
        transform.localPosition = cell.transform.localPosition;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(grountCheck.position, groundDistance, groundMask);

        Debug.Log(isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
