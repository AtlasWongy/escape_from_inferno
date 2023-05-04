using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField]
    float speed = 5;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update() {
        ProcessInputs();
    }

    public void FixedUpdate() {

        if (DialogueManager.GetInstance().dialogueIsPlaying) {
            return;
        }
        Move();
    }

    public void ProcessInputs() {
        Vector2 inputVector = InputManager.GetInstance().GetMoveDirection();
        moveDirection = new Vector2(inputVector.x, inputVector.y);
    }

    public void Move() {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
