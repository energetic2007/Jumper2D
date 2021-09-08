using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {

        if (!player)
            player = FindObjectOfType<Player>().transform;

    }
    private void Update()
    {
        pos = player.position;
        pos.z = -10.0f;
        // pos.y += 2f;
        pos.x = 0f;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
