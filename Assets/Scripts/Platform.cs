using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject platformPref;
    public static Platform Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            float RandX = Random.Range(0, 0);
            float RandY = Random.Range(transform.position.y + 20f, transform.position.y + 22f);
            transform.position = new Vector3(RandX, RandY, 0f);
        }
    }
}
