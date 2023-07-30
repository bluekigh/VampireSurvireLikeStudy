using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rigid2d;
    private Animator anim;

    public Vector2 inputvector;    

    public float speed;
    
    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        inputvector = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        // // add force
        // rigid2d.AddForce (inputvector);
        //
        // // velocity
        // rigid2d.velocity = inputvector;

        Vector2 nextVec = Time.fixedDeltaTime * inputvector.normalized * speed ;
        // move position
        rigid2d.MovePosition(rigid2d.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed",inputvector.magnitude);
        if (inputvector.x != 0)
        {
            sprite.flipX = inputvector.x < 0;
        }
    }
}
