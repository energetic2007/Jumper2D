using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEntity : Entity
{
    private Vector3 dir;
    //public GameObject flyEntity;
    [SerializeField] private GameObject flyEntityPref;
    private void Awake()
    {
        lives = 1;
    }
    private void Start()
    {
        dir = transform.right;

        Vector3 SpawnPos = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            SpawnPos.x = 0;
            SpawnPos.y += Random.Range(20, 40);
            SpawnPos.z = 0;
            Instantiate(flyEntityPref, SpawnPos, Quaternion.identity);
        }
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Mathf.Abs(transform.position.x) >= 2.5f)
        {
            Debug.Log("STOP");
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            float RandX = Random.Range(0, 0);
            float RandY = Random.Range(transform.position.y + 50f, transform.position.y + 60f);
            transform.position = new Vector3(RandX, RandY, 0f);
        }
        if (other.tag == "player")
        {
            GetDamage();
        }
    }
}
