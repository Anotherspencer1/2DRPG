using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Motor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movement;
    public Rigidbody2D rb;

    void OnMovement(InputValue value){
        movement = value.Get<Vector2>();
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
