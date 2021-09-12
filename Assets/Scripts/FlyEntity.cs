using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEntity : Entity
{
    private Vector3 dir;
    private void Awake()
    {
        lives = 1;
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
            float RandX = Random.Range(0, 0);
            float RandY = Random.Range(transform.position.y + 50f, transform.position.y + 60f);
            transform.position = new Vector3(RandX, RandY, 0f);
        }
        if (other.tag == "player")
        {
            GetDamage();
        }
    }
}
