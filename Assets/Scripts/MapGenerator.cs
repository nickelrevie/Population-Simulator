using UnityEngine;
using System.Collections;

public class MapGenerator{

    private int mapHeight = 40;
    private int mapWidth = 40;

    private TileMap generatedMap;

    public TileMap CreateTileMap() //Add parameters when procedural generation is put in.
    {
        GameObject[,] tileMap = new GameObject[mapHeight, mapWidth];
        for (int i = 0; i < mapHeight; i++)
        {
            for (int k = 0; k < mapWidth; k++)
            {
                tileMap[i, k] = GameObject.Instantiate(Resources.Load("Prefabs/Tile Base"),
                    new Vector3(3.5f * k + 1.75f * (i % 2), 3.075f * i, 0),
                    Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }
        generatedMap = new TileMap();
        generatedMap.SetMap(tileMap);
        GenerateRandomGeographyMap(generatedMap);
        return GetGeneratedTileMap();
    }

    public TileMap GetGeneratedTileMap()
    {
        return generatedMap;
    }

    void GenerateRandomGeographyMap(TileMap tileMap)
    {
        GameObject[,] map = tileMap.GetMap();
        for (int i = 0; i < mapHeight; i++)
        {
            for (int k = 0; k < mapWidth; k++)
            {
                Geography.Biome randomBiome = (Geography.Biome)Random.Range(0, 7);
                Geography geography = GeographyManager.CreateGeography(randomBiome);
                map[i, k].GetComponent<Tile>().ApplyGeography(geography);
            }
        }
    }
}
