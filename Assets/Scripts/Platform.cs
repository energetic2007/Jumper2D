using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform Instance { get; set; }
    [SerializeField] private LevelGeneration levelGeneration;
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            // GetComponent<LevelGeneration>().RegeneratePlaform(this.gameObject);
            // FindObjectOfType<LevelGeneration>().RegeneratePlaform(this.gameObject);
            this.levelGeneration.RegeneratePlaform(this.gameObject);
        }
    }
}
