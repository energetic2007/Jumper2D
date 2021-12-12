using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IEntity
{
    int lives { get; set; }
    void Die();
}