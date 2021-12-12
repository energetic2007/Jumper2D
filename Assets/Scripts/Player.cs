using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //public static Player Instance { get; set; }
    private float horizontal;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    private void Awake()
    {
        lives = 3;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
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

        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.relativeVelocity.y > 0) || (collision.gameObject == Platform.Instance.gameObject))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
            Die();
        if (other.tag == "enemy")
            GetDamage();
    }


}