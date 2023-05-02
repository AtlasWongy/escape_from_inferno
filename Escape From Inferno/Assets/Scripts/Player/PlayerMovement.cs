using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInputActions playerInputActions;
    [SerializeField]
    float speed = 5;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        Debug.Log("I am awake!");
    }

    public void FixedUpdate() {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(inputVector);
        rb.AddForce(new Vector2(inputVector.x, inputVector.y) * speed, ForceMode2D.Force);
    }
}
