using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{ 
    public float _normalSpeed;
    private float _moveSpeed;
    private Rigidbody rb;
    private Vector2 inputValue;
    private StateHandler handler;

    void Awake()
    {
        _moveSpeed = _normalSpeed;
        rb = GetComponent<Rigidbody>();
        handler = GetComponent<StateHandler>();
    }

    void FixedUpdate()
    {
        Direction();
    }

    //Sets the _movespeed variable equal to the paramater NewMoveSpeed.
    public void ChangeMovementSpeed(float NewMoveSpeed)
    {
        _moveSpeed = NewMoveSpeed;
    }

    //This function can be called to reset the movement speed to it's default value.
    public void ChangeMovementSpeed()
    {
        ChangeMovementSpeed(_normalSpeed);
    }

    private void Direction()
    {
        if (handler.CanAct)
        {
            //Gets the direction of the players input
            Vector3 direction = new Vector3(inputValue.x, 0, inputValue.y);

            Vector3 velocity = direction * _moveSpeed;
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
            Vector3 facingrotation = Vector3.Normalize(new Vector3(inputValue.x, 0, inputValue.y));

            //This condition prevents from spamming "Look rotation viewing vector is zero" when not moving.
            if (facingrotation != Vector3.zero)
            {
                transform.forward = facingrotation;
            }
            //To prevent players from climbing up.
            if(direction.y > 0)
            {
                direction.y = 0;
            }
        }
    }

    private void OnMovement(InputValue val)
    {
        inputValue = val.Get<Vector2>();
    }
}
