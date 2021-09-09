using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    /*public static Platform Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }*/
    [SerializeField] private GameObject platformPref;
    private void Start()
    {
        Vector3 SpawnPos = new Vector3();
        for (int i = 0; i < 10; i++)
        {
            SpawnPos.x = Random.Range(0, 0);
            SpawnPos.y += Random.Range(2, 3);
            SpawnPos.z = 0;
            Instantiate(platformPref, SpawnPos, Quaternion.identity);
        }
    }
}
