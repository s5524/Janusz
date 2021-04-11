using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Maze maze;
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = 20.0f;
    public float rotationSpeed = 100.0F;
    public Transform grountCheck;
    public float groundDistance = 1f;

    public LayerMask groundMask;

    public Inventory inventory;

    private Vector3 moveDirection = Vector3.zero;
    private void OnTriggerEnter(Collider other)
    {

        IInventoryItems item = other.GetComponent<IInventoryItems>();

        if (item != null)
        {
            inventory.AddItem(item);

        }
        if (item == null)
        {

            var firstSpace = other.gameObject.name.ToString().IndexOf(' ');
            var secoundSpace = other.gameObject.name.ToString().IndexOf(' ', firstSpace + 1);
            var comaIndex = other.gameObject.name.ToString().IndexOf(',');

            var yIndex = Int32.Parse(other.gameObject.name.ToString().Substring(comaIndex + 1));
            var xIndex = Int32.Parse(other.gameObject.name.ToString().Substring(secoundSpace, comaIndex - secoundSpace));

            maze.GetCell(xIndex, yIndex).OnPlayerEntered();

        }



    }

    internal void SetCells(Maze maze)
    {
        this.maze = maze;
    }

    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")) ;
            // moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
