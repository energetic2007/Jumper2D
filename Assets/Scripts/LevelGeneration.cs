using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // TODO Заменить на реальный размер экрана
    const int ENTITY_SPAWN_SCREEN_OFFSET_Y = 10;
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

    private void RespawnEntity(GameObject pref, SpawnField spawnField, float yOffset)
    {
        var SpawnPos = new Vector2();
        SpawnPos.x = Random.Range(spawnField.minX, spawnField.maxX);
        SpawnPos.y = Random.Range(spawnField.minY, spawnField.maxY) + yOffset;
        pref.transform.position = SpawnPos;
    }

    private void InitialGenerate(GameObject pref, SpawnField spawnField)
    {
        for (int i = 0; i < spawnField.amount; i++)
        {
            RespawnEntity(Instantiate(pref, transform), spawnField, 0f + i);
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

    public void RegenerateFlyEnemy(GameObject flyEnemy)
    {
        RespawnEntity(flyEnemy, this.flyEnemySpawn, flyEnemy.transform.position.y + ENTITY_SPAWN_SCREEN_OFFSET_Y);
    }

    public void RegenerateLifeEntity(GameObject lifeEntity)
    {
        RespawnEntity(lifeEntity, this.lifeEntitySpawn, lifeEntity.transform.position.y + ENTITY_SPAWN_SCREEN_OFFSET_Y);
    }

    public void RegenerateFollowingEnemy(FollowingEnemy followingEnemy)
    {
        RespawnEntity(followingEnemy.gameObject, this.followingEnemySpawn, followingEnemy.transform.position.y + ENTITY_SPAWN_SCREEN_OFFSET_Y);
    }

    public void RegeneratePlaform(GameObject platform)
    {
        RespawnEntity(platform, this.platformSpawn, platform.transform.position.y + ENTITY_SPAWN_SCREEN_OFFSET_Y);
    }
}
