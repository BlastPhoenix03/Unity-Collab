using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Rigidbody2D rb;
    private bool facingright;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raycastSize;
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        return Physics2D.OverlapCircle(groundCheck.position, raycastSize, groundLayer);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * Speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(facingright && horizontal < 0 || !facingright && horizontal > 0f)
        {
            facingright = !facingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
        }
    }
   
}
