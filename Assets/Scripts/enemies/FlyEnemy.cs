using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Entity, IEntity
{
  private Vector3 dir;
  public void Awake()
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
      dir *= -1f;
    }
    transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
  }
  public void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "DeathZone")
    {
      LevelGeneration.Regenerate(spawnField, this.gameObject);
    }
    if (other.tag == "Player")
    {
      GetDamage();
    }
  }
  public override void Die()
  {
    LevelGeneration.Regenerate(this.spawnField, this.gameObject);
  }
}
