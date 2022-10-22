using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Entity, IEntity
{
    private Vector3 dir;
    private Vector3 centerPos;
    [SerializeField] GameObject player;
    [SerializeField] private LevelGeneration levelGeneration;
    public void Awake()
    {
        lives = 1;
        dir = transform.right;
        UpdateCenterPosition();
    }
    private void Update()
    {
        if (player.transform.position.y < centerPos.y - 10)
        {
            OnHold();
        }

        if (player.transform.position.y >= centerPos.y - 10)
        {
            Follow();
        }

        if (player.transform.position.y >= centerPos.y + 10)
        {
            OnHold();
        }
    }
    private void UpdateCenterPosition()
    {
        centerPos = transform.position;
    }
    private void OnHold()
    {
        if (Mathf.Abs(transform.position.x) >= 2.5f)
        {
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }
    private void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            this.levelGeneration.RegenerateFollowingEnemy(transform.position.y);
            UpdateCenterPosition();
        }
        if (other.tag == "Player")
        {
            GetDamage();
        }
    }
    public override void Die()
    {
        this.levelGeneration.RegenerateFollowingEnemy(transform.position.y);
        UpdateCenterPosition();
    }
}

enum FollowEnemyState
{
    OnHold,
    Follow
}
