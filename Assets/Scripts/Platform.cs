using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }
}
