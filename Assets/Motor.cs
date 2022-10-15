using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Motor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movement;
    public bool is_attacking;
    public Rigidbody2D rb;
    public Animator anim;

    void OnMovement(InputValue value){
        movement = value.Get<Vector2>();
        anim.SetFloat("movement_x", movement.x);
        anim.SetFloat("movement_y", movement.y);
        anim.SetFloat("movement_speed", movement.magnitude);
    }

    void OnAttack(InputValue value){
        if (value.Get<float>() == 1f)
        {
            anim.SetBool("is_attacking", true);
        }
        else
        {
            anim.SetBool("is_attacking", false);
        }

    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
