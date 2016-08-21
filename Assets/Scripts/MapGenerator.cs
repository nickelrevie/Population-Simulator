using UnityEngine;
using System.Collections;

public class MapGenerator{

    private int mapHeight = 40;
    private int mapWidth = 40;

    private TileMap generatedMap;

    public TileMap createTileMap() //Add parameters when procedural generation is put in.
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
        generatedMap.setMap(tileMap);
        generateRandomGeographyMap(generatedMap);
        return getGeneratedTileMap();
    }

    public TileMap getGeneratedTileMap()
    {
        return generatedMap;
    }

    void generateRandomGeographyMap(TileMap tileMap)
    {
        GameObject[,] map = tileMap.getMap();
        for (int i = 0; i < mapHeight; i++)
        {
            for (int k = 0; k < mapWidth; k++)
            {
                Geography.Biome randomBiome = (Geography.Biome)Random.Range(0, 7);
                Geography geography = GeographyManager.createGeography(randomBiome);
                map[i, k].GetComponent<Tile>().applyGeography(geography);
            }
        }
    }
}
