using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Player player;
    void Start()
    {

    }

    void Update()
    {
        int numChildren = transform.childCount;

        if (numChildren > player.lives)
        {
            Destroy(transform.GetChild(numChildren - 1).gameObject);
        }
    }
}
