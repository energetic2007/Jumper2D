using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public static Player Instance { get; set; }
    private float horizontal;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        // Instance = this;
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        // CheckGround();
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }
        if (Input.acceleration.x < 0)
        {
            sprite.flipX = false;
        }
        if (Input.acceleration.x > 0)
        {
            sprite.flipX = true;
        }

        rb.velocity = new Vector2(Input.acceleration.x * 10f, rb.velocity.y);

        /* if (isGrounded)
         {
             Debug.Log("Jump");
             rb.velocity = Vector2.up * jumpForce;

         }*/
    }
    /*    private void CheckGround()
        {
            Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.05f);
            isGrounded = collider.Length > 1;
        }
        */

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y > 0)
        //if (collision.gameObject == Platform.Instance.gameObject)
        {
            Debug.Log("Jump");
            rb.velocity = Vector2.up * jumpForce;
        }
    }


}