using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEntity : Entity
{
    private Vector3 dir;
    public GameObject flyEntity;
    private void Awake()
    {
        lives = 1;
    }
    private void Start()
    {
        dir = transform.right;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Mathf.Abs(transform.position.x) >= 2.5f)
        {
            Debug.Log("STOP");
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            Die();
        }
        if (other.tag == "player")
        {
            GetDamage();
        }
    }
}
