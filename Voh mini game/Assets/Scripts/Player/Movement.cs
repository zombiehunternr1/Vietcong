using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _moveSpeed = 15f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Direction();
    }

    private void Direction()
    {
        //Gets the direction of the players input
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //This prevents going faster when running diagonically
        if (direction.sqrMagnitude > 1f)
        {
            direction = direction.normalized; 
        }

        //Multiplies the movement speed and adds the speed to the charactercontroller with the new directions
        Vector3 velocity = direction * _moveSpeed;
        controller.Move(velocity * Time.deltaTime);
        Vector3 facingrotation = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));

        //This condition prevents from spamming "Look rotation viewing vector is zero" when not moving.
        if (facingrotation != Vector3.zero)
        {
            transform.forward = facingrotation;
        }   
    }
}
