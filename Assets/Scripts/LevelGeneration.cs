using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private GameObject flyEntityPref;
    [SerializeField] private SpawnField flyEntitySpawn;

    private void Start()
    {
        SpawnEntity(flyEntityPref, flyEntitySpawn);
    }

    private void SpawnEntity(GameObject pref, SpawnField flyEntitySpawn)
    {
        Vector3 SpawnPos = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            SpawnPos.x = Random.Range(flyEntitySpawn.minX, flyEntitySpawn.maxX);
            SpawnPos.y += Random.Range(flyEntitySpawn.minY, flyEntitySpawn.maxY);
            SpawnPos.z = 0;
            Instantiate(pref, SpawnPos, Quaternion.identity);
        }
    }
}

