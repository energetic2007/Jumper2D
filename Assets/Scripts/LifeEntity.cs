using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEntity : Entity, IEntity
{
    [SerializeField] private LevelGeneration levelGeneration;
    public void Awake()
    {
        lives = 1;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            this.levelGeneration.RegenerateLifeEntity(gameObject);
        }
        if (other.tag == "Player")
        {
            GetDamage();
        }
    }
    public override void Die()
    {
        this.levelGeneration.RegenerateLifeEntity(gameObject);

    }

}
