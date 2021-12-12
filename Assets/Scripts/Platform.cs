using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
  public static Platform Instance { get; set; }
  [SerializeField] private SpawnField spawnPos;
  private void Awake()
  {
    Instance = this;
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "DeathZone")
    {
      LevelGeneration.Regenerate(spawnPos, this.gameObject);
    }
  }
}
