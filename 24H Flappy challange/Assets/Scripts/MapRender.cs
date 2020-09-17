using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapRender : MonoBehaviour
{
    private const int mapLength = 1000;
    [Header("Grass")]
    public GameObject grassPrefab;
    private const float distanceBetweenGrass = 10.2f;
    private Vector2 firstGrassPosition;
    [Header("Columns")]
    public GameObject columnsPrefab;
    private const float distanceBetweenColumns = 10f;
    private Vector2 firstColumnsPosition;
    [Header("Background")]
    public GameObject backgroundPrefab;
    private const float distanceBetweenBackgroundSprites = 20.45f;


    private void Start()
    {
        firstGrassPosition = new Vector2(-5.2f, -4f);
        firstColumnsPosition = new Vector2(15f, -2f);
        for (int i = 0; i < mapLength; ++i)
        {
            var grass = Instantiate(grassPrefab, this.transform) as GameObject;
            grass.transform.position = new Vector3(firstGrassPosition.x + ((i + 1) * distanceBetweenGrass), firstGrassPosition.y, 0f);

            var columns = Instantiate(columnsPrefab, this.transform) as GameObject;
            var randomizedPosY = Random.Range(-4.95f, -1.45f);
            columns.transform.position = new Vector3(firstColumnsPosition.x + ((i + 1) * distanceBetweenColumns), randomizedPosY, 0f);

            var backgroundSprite = Instantiate(backgroundPrefab, this.transform) as GameObject;
            backgroundSprite.transform.position = new Vector3(i * distanceBetweenBackgroundSprites, 0f, 0f);
        }

    }
}
