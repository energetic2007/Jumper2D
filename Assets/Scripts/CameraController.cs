using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>().transform;
    }
    private void Update()
    {
        var playerPos = new Vector3(0, player.position.y - 2, -10);
        if (playerPos.y > transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime + 0.8f);
        }
    }
}

