﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public float maxSpawnAngle;
    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;

    

    public Vector2 spawnSizeMinMax;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            GenerateFallingBlock();
        }

    }

    void GenerateFallingBlock()
    {
        float spawnAngle = Random.Range(-maxSpawnAngle, maxSpawnAngle);
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);

        GameObject newBlock = (GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
        newBlock.transform.localScale = Vector2.one * spawnSize;
        
    }

}
