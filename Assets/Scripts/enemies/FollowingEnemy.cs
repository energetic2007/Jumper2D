using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Entity, IEntity
{
  private Vector3 dir;
  private Vector3 centerPos;
  [SerializeField] GameObject player;
  public void Awake()
  {
    lives = 1;
    dir = transform.right;
    UpdateCenterPosition();
  }
  private void Update()
  {
    // OnHold();
    // Follow();
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
    Debug.Log("on hold");
    if (Mathf.Abs(transform.position.x) >= 2.5f)
    {
      dir *= -1f;
    }
    transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
  }
  private void Follow()
  {
    Debug.Log("follow");

    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
  }
  public void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "DeathZone")
    {
      LevelGeneration.Regenerate(spawnField, this.gameObject);
      UpdateCenterPosition();
    }
    if (other.tag == "Player")
    {
      GetDamage();
    }
  }
  public override void Die()
  {
    LevelGeneration.Regenerate(this.spawnField, this.gameObject);
    UpdateCenterPosition();
  }
}

enum FollowEnemyState
{
  OnHold,
  Follow
}
