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
    private void Start()
    {
        SpawnEntity(flyEntityPref, flyEntitySpawn);
        SpawnEntity(PlatformPref, PlatformSpawn);
    }

    private void SpawnEntity(GameObject pref, SpawnField spawnField)
    {
        Vector3 SpawnPos = new Vector3();
        for (int i = 0; i < spawnField.amount; i++)
        {
            SpawnPos.x = Random.Range(spawnField.minX, spawnField.maxX);
            SpawnPos.y += Random.Range(spawnField.minY, spawnField.maxY);
            SpawnPos.z = 0;
            Instantiate(pref, SpawnPos, Quaternion.identity);
        }
    }

    public static void Regenerate(SpawnField spawnField, GameObject gameObject)
    {
        float RandX = Random.Range(spawnField.minX, spawnField.maxX);
        float RandY = Random.Range(gameObject.transform.position.y + 20, gameObject.transform.position.y + 22);
        gameObject.transform.position = new Vector3(RandX, RandY, 0f);
    }
}
