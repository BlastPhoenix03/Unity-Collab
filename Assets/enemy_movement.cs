using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;

    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
       collider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        if (IsGrounded()) {
            rb.velocity = new Vector2 (rb.velocity.x - speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, 0.02, groundLayer);
        return raycastHit.collider != false;
       
    }
}
