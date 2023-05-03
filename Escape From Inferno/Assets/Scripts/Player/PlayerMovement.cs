using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInputActions playerInputActions;
    private Vector2 moveDirection;
    [SerializeField]
    float speed = 5;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public void Update() {
        ProcessInputs();
    }

    public void FixedUpdate() {
        Move();
    }

    public void ProcessInputs() {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(inputVector);
        // rb.AddForce(new Vector2(inputVector.x, inputVector.y) * speed);
        moveDirection = new Vector2(inputVector.x, inputVector.y);
    }

    public void Move() {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
