using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEntity : Entity, IEntity
{
    public void Awake()
    {
        lives = 1;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            LevelGeneration.Regenerate(spawnField, this.gameObject);
        }
        if (other.tag == "Player")
        {
            Debug.Log("a");
        }
    }
    public override void Die()
    {
        LevelGeneration.Regenerate(this.spawnField, this.gameObject);
    }
}
