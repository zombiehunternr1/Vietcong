using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public bool _canMove;
    public bool _hitSpike;
    public float _normalSpeed;
    public AudioSource Shot;
    public AudioSource Speared;
    private float _moveSpeed; 
    private Rigidbody rb;
    private Vector2 inputValue;
    private StateHandler handler;
    private Animator animController;

    void Awake()
    {
        _hitSpike = false;
        _moveSpeed = _normalSpeed;
        rb = GetComponent<Rigidbody>();
        handler = GetComponent<StateHandler>();
        animController = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        //Checks if the boolean _canMove is true. If so it means the game has started and the players are allowed to move around.
        if (_canMove)
        {
            Direction();
        }      
    }

    //Sets the _movespeed variable equal to the paramater NewMoveSpeed and sets the _animSpeed variable equal to the value in the variable _moveSpeed.
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
            //Check if the vector 2 variable inputValue isn't zero. If so it means the player is moving the joystick and needs to move the player around while playing the running animation.
            //If not that means the player is standing still so it needs to play the idle animation.
            if(inputValue != Vector2.zero)
            {
                animController.SetBool("IsRunning", true);
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
                if (direction.y > 1.26)
                {
                    direction.y = 1.25f;
                }
                //Checks if the player is falling down. If so it sets the IsRunning, IsBounce and IsMud to false, sets the bool IsFalling to true and starts the coroutine DisableMovement.
                if(transform.position.y < 1.249)
                {
                    animController.SetBool("IsRunning", false);
                    animController.SetBool("IsBounce", false);
                    animController.SetBool("IsMud", false);
                    animController.SetBool("IsFalling", true);
                    StartCoroutine(DisableMovement());
                }
            }
            else
            {
                animController.SetBool("IsRunning", false);
            }
        }
    }

    private void OnMovement(InputValue val)
    {
        inputValue = val.Get<Vector2>();
    }

    //This coroutine sets the _hitSpike to true and the _canMove boolean to false after half a second later.
    //Sets the IsFalling bool to false and sets the IsFlat bool to true.
    IEnumerator DisableMovement()
    {
        rb.detectCollisions = false;
        _hitSpike = true;
        rb.detectCollisions = true;
        yield return new WaitForSeconds(0.5f);
        _canMove = false;
        animController.SetBool("IsFalling", false);
        animController.SetBool("IsFlat", true);
    }
}
