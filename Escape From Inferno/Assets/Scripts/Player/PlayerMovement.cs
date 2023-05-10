using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool _facingRight = true;
    private Animator _animator;


    // private Animator _animator;
    public LayerMask walkableSurface;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        ProcessInputs();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void ProcessInputs()
    {
        Vector2 inputVector = InputManager.GetInstance().GetMoveDirection();
        moveDirection = new Vector2(inputVector.x, inputVector.y);
        _animator.SetFloat("Horizontal", moveDirection.x);
        _animator.SetFloat("Vertical", moveDirection.y);
        _animator.SetFloat("Speed", moveDirection.SqrMagnitude());
        Flip(moveDirection.x);
    }

    public void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public void Flip(float direction)
    {
        if (!_facingRight && direction > 0)
        {
            transform.localScale = new Vector3(
                - 1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            _facingRight = true;
            Debug.Log($"I am facing the right: {_facingRight}");
        }
        else if (_facingRight && direction < 0)
        {
            transform.localScale = new Vector3(
                -1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            _facingRight = false;
            Debug.Log($"I am facing the right: {_facingRight}");
        }
    }
}