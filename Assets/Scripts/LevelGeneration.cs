using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private SpawnField flyEnemySpawn;
    [SerializeField] private GameObject flyEnemyPref;

    [Space(20)]
    [SerializeField] private SpawnField platformSpawn;
    [SerializeField] private GameObject platformPref;

    [Space(20)]
    [SerializeField] private SpawnField lifeEntitySpawn;
    [SerializeField] private GameObject lifeEntityPref;

    [Space(20)]
    [SerializeField] private SpawnField followingEnemySpawn;
    [SerializeField] private GameObject followingEnemyPref;
    private void Start()
    {
        SpawnEntity(flyEnemyPref, flyEnemySpawn);
        SpawnEntity(platformPref, platformSpawn);
        SpawnEntity(lifeEntityPref, lifeEntitySpawn);
        SpawnEntity(followingEnemyPref, followingEnemySpawn);
    }

    private void SpawnEntity(GameObject pref, SpawnField spawnField)
    {
        var SpawnPos = new Vector2();
        for (int i = 0; i < spawnField.amount; i++)
        {
            SpawnPos.x = Random.Range(spawnField.minX, spawnField.maxX);
            SpawnPos.y += Random.Range(spawnField.minY, spawnField.maxY);
            Instantiate(pref, SpawnPos, Quaternion.identity, transform);
        }
    }

    public static void Regenerate(SpawnField spawnField, GameObject gameObject)
    {
        float RandX = Random.Range(spawnField.minX, spawnField.maxX);
        float RandY = Random.Range(gameObject.transform.position.y + spawnField.minY, gameObject.transform.position.y + spawnField.maxY);
        gameObject.transform.position = new Vector2(RandX, RandY);
    }
}
