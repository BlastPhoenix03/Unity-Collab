using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
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
    
    //Callin the components
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
       boxCollider2D = GetComponent<CapsuleCollider2D>();
        
    }

    // Update is called once per frame
    //INPUTS
    void Update()
    {
        //Movement
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        //Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            rb.gravityScale = 5;
            
           
        }
        // If hold jump higher
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (IsGrounded())
        {
            rb.gravityScale = 1f;
        }

        
    }


   //Assigning rb.velocity in a 2 factor (x,y)
    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * Speed, rb.velocity.y);
    }

     //Stare forward
   
    private void Flip()
    {
        if(facingright && horizontal < 0 || !facingright && horizontal > 0f)
        {
            facingright = !facingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
        }
    }

    // Deny flappy birb
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, raycastSize, groundLayer);
        return raycastHit.collider != false;
       
    }

    private void timerWorker()
    {
        timer++;
        if ( timer <10)
        {
            timer = 0;
        }
    }
   
}// Hi shadow, if u see this then write comment with "//".
