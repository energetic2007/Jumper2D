using System.Collections;
using UnityEngine;
using System;

public delegate void Delegate();
public class Player : Entity
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private float jumpForce;
    [SerializeField] private float xMoveSpeed;
    private void Awake()
    {
        lives = 3;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.acceleration.x < 0)
            sprite.flipX = false;
        else
            sprite.flipX = true;

        if (lives > 0)
        {
            float xOffset = Input.GetAxisRaw("Horizontal");
            transform.position = new Vector2(transform.position.x + (xOffset * xMoveSpeed), transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.y > 0)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            EventPublisher.getInstance().CreatePlayerDieEvent();
            StartCoroutine(WaitDie());
        }
        if (other.tag == "enemy")
            GetDamage();
        if (other.tag == "life")
            lives++;
    }
    IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(1);
        Die();
        StopCoroutine(WaitDie());
    }
    public override void Die()
    {
        base.Die();
        MenuController.Instance.UpdateGameState(GameState.TryAgain);
    }
}