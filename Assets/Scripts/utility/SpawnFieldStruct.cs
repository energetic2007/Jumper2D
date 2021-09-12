using System;
using UnityEngine;


[Serializable]
public struct SpawnField
{
    [SerializeField] public float minX;
    [SerializeField] public float minY;
    [SerializeField] public float maxX;
    [SerializeField] public float maxY;
}