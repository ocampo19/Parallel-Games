using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;
    public int numberOfEnemies;
    public float spawnTime = 3f;
    public int min, max;


    void Start()
    {

        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Spawn()
    {
        Instantiate(enemy, GeneratedPosition(), Quaternion.identity);
    }

    Vector2 GeneratedPosition()
    {
        int x, y;
        x = UnityEngine.Random.Range(min, max);
        y = UnityEngine.Random.Range(min, max);
        return new Vector2(x, y);
    }

}