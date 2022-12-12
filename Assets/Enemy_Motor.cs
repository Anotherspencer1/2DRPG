using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy_Motor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movement;
    public bool is_attacking;
    public Rigidbody2D rb;
    public Animator anim;
    public Transform player;

    void Update(){
        movement = player.position - transform.position;
        movement.Normalize();
        anim.SetFloat("movement_x", movement.x);
        anim.SetFloat("movement_y", movement.y);
        anim.SetFloat("movement_speed", movement.magnitude);
        if(Mathf.Abs(movement.x) > 0.2f && Mathf.Abs(movement.y) < 0.2)
        {
            anim.SetFloat("last_x", movement.x);
            anim.SetFloat("last_y", 0);
        }
        else if(Mathf.Abs(movement.y) > 0.2f & Mathf.Abs(movement.x) < 0.2)
        {
            anim.SetFloat("last_y", movement.y);
            anim.SetFloat("last_x", 0);
        }
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
