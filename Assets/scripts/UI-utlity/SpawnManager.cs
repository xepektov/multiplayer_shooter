using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawn_instance;

    spawnpoint[] spawnpoints;

    // Start is called before the first frame update
    void Awake()
    {
        spawn_instance = this;
        spawnpoints = GetComponentsInChildren<spawnpoint>();
    }

    public Transform getSpawnpoint()
    {
        return spawnpoints[Random.Range(0, spawnpoints.Length)].transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
