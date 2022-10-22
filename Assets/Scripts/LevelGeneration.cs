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
        InitialGenerate(flyEnemyPref, flyEnemySpawn);
        InitialGenerate(platformPref, platformSpawn);
        InitialGenerate(lifeEntityPref, lifeEntitySpawn);
        InitialGenerate(followingEnemyPref, followingEnemySpawn);
    }

    public void SpawnEntity(GameObject pref, SpawnField spawnField, float yOffset)
    {
        var SpawnPos = new Vector2();
        SpawnPos.x = Random.Range(spawnField.minX, spawnField.maxX);
        SpawnPos.y = Random.Range(spawnField.minY, spawnField.maxY) + yOffset;
        pref.transform.position = SpawnPos;

    }

    public void InitialGenerate(GameObject pref, SpawnField spawnField)
    {
        for (int i = 0; i < spawnField.amount; i++)
        {
            SpawnEntity(Instantiate(pref), spawnField, 0f + i);
        }
    }

    /*
        private void Regenerate(GameObject gameObject, SpawnField spawnField)
        {
            float RandX = Random.Range(spawnField.minX, spawnField.maxX);
            float RandY = Random.Range(gameObject.transform.position.y + spawnField.minY, gameObject.transform.position.y + spawnField.maxY);
            gameObject.transform.position = new Vector2(RandX, RandY);
        }
    */

    public void RegenerateFlyEnemy(float yOffset)
    {
        SpawnEntity(flyEnemyPref, this.flyEnemySpawn, yOffset);
    }

    public void RegenerateLifeEntity(float yOffset)
    {
        SpawnEntity(lifeEntityPref, this.lifeEntitySpawn, yOffset);
    }

    public void RegenerateFollowingEnemy(float yOffset)
    {
        SpawnEntity(followingEnemyPref, this.followingEnemySpawn, yOffset);
    }

    public void RegeneratePlaform(GameObject platform)
    {
        SpawnEntity(platform, this.platformSpawn, platform.transform.position.y + 10);
    }
}
