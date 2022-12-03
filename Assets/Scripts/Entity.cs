using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    public int lives { get; set; }


    public virtual void GetDamage()
    {
        lives--;
        if (lives < 1)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        lives = 0;
    }
}
