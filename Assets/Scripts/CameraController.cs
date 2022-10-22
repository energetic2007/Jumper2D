using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private bool _checkPlauerStat = false;
    private void Awake()
    {
        if (!_player)
            _player = FindObjectOfType<Player>().transform;

        EventPublisher.getInstance().OnPlayerDie += OnPlayerDie;
    }
    private void Update()
    {
        var playerPos = new Vector3(0, _player.position.y + 2, -10);
        var cameraPos = new Vector3(0, transform.position.y - 10, -10);
        if (playerPos.y > transform.position.y)
            transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime + 0.8f);

        if (_checkPlauerStat)
            transform.position = Vector3.Lerp(transform.position, cameraPos, Time.deltaTime);
    }

    private void OnPlayerDie()
    {
        _checkPlauerStat = true;
    }
}

