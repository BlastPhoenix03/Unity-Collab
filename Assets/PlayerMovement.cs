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
    [SerializeField]private bool facingright;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raycastSize;
    private CapsuleCollider2D boxCollider2D;
    public float gravityweight;
    public float timer = 0f;

    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
       boxCollider2D = GetComponent<CapsuleCollider2D>();
        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            rb.gravityScale = 5;
            
           
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (IsGrounded())
        {
            rb.gravityScale = 1f;
        }

        
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

    /* Deny flappy birb
    Huh??? */
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, raycastSize, groundLayer);
        return raycastHit.collider != false;
       
    }

    private void timerWorker()
    {
        timer++;
        if (timer < 10)
        {
            timer = 0;
        }
    }
   
}// Hi Shadow!
// Dear Blast, I'm not stupid. I can understand your code without comments. And I also know the syntax of C#. If I ever need explanations on a thing, I'll text you. Until then, don't write obvious comment. There's a meme about this: code: *stop sign*, comment: "this is a stop sign". Understand now what I'm trying to say? Good then. So, don't write obvious comment. Next time, think about it: do you really need to write this comment? Will it rather "pollute" the code?