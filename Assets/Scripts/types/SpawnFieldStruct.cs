using System;
using UnityEngine;


[Serializable]
public struct SpawnField
{
    [SerializeField] public int amount;
    [SerializeField] public float minX;
    [SerializeField] public float maxX;
    [SerializeField] public float minY;
    [SerializeField] public float maxY;
}