using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject flyEntityPref;
    [SerializeField]
    private SpawnField flyEntitySpawn;
    [SerializeField]
    private GameObject PlatformPref;
    [SerializeField]
    private SpawnField PlatformSpawn;
    [SerializeField] private Transform LevelGenerator;
    private void Start()
    {
        SpawnEntity(flyEntityPref, flyEntitySpawn);
        SpawnEntity(PlatformPref, PlatformSpawn);
    }

    private void SpawnEntity(GameObject pref, SpawnField spawnField)
    {
        var SpawnPos = new Vector2();
        for (int i = 0; i < spawnField.amount; i++)
        {
            SpawnPos.x = Random.Range(spawnField.minX, spawnField.maxX);
            SpawnPos.y += Random.Range(spawnField.minY, spawnField.maxY);
            Instantiate(pref, SpawnPos, Quaternion.identity, LevelGenerator);
        }
    }

    public static void Regenerate(SpawnField spawnField, GameObject gameObject)
    {
        float RandX = Random.Range(spawnField.minX, spawnField.maxX);
        float RandY = Random.Range(gameObject.transform.position.y + spawnField.minY, gameObject.transform.position.y + spawnField.maxY);
        gameObject.transform.position = new Vector2(RandX, RandY);
    }
}
