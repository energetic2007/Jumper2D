using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Entity, IEntity
{
    private Vector3 dir;
    private Vector3 centerPos;
    [SerializeField] GameObject player;
    [SerializeField] private LevelGeneration levelGeneration;
    [SerializeField] private float targetRange;
    [SerializeField] private float speed;

    public void Start()
    {
        lives = 1;
        dir = transform.right;
        UpdateCenterPosition();
    }

    private void Update()
    {
        if (Mathf.Abs(player.transform.position.y - centerPos.y) < targetRange)
        {
            Follow();
        }
        else
        {
            OnHold();
        }
    }

    public void UpdateCenterPosition()
    {
        centerPos = transform.position;
    }

    private void OnHold()
    {
        if (Mathf.Abs(transform.position.x) >= targetRange)
        {
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }

    private void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.transform.position, player.transform.position, Time.deltaTime * speed);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            this.levelGeneration.RegenerateFollowingEnemy(this);
            UpdateCenterPosition();
        }
        if (other.tag == "Player")
        {
            Debug.Log("collide");
            GetDamage();
        }
    }

    public override void Die()
    {
        this.levelGeneration.RegenerateFollowingEnemy(this);
        UpdateCenterPosition();
    }
}

