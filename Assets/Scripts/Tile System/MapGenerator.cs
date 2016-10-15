using UnityEngine;
using System.Collections;

public class MapGenerator{

    //Set height and width to make the map.
    //In future, add a way to control the generation before making the map in the program.
    private int mapHeight = 40;
    private int mapWidth = 40;

    //Is the tilemap that is generated.
    private TileMap generatedMap;

    //Add parameters when procedural generation is put in.
    public TileMap CreateTileMap()
    {
        //Create two dimensional object array for the tile map.
        GameObject[,] tileMap = new GameObject[mapHeight, mapWidth];

        //Creates a tile for each spot in the array and sets its location and orientation.
        for (int i = 0; i < mapHeight; i++)
        {
            for (int k = 0; k < mapWidth; k++)
            {
                tileMap[i, k] = GameObject.Instantiate(Resources.Load("Prefabs/Tile Base"),
                    new Vector3(3.5f * k + 1.75f * (i % 2), 3.075f * i, 0),
                    Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }

        //Creates a new TileMap Object and sets the held game object array in the TileMap
        generatedMap = new TileMap();
        generatedMap.SetMap(tileMap);

        //Generates the random geographies ans returns the TileMap the method makes.
        GenerateRandomGeographyMap(generatedMap);
        return GetGeneratedTileMap();
    }

    //Returns the tile map.
    public TileMap GetGeneratedTileMap()
    {
        return generatedMap;
    }

    //Generates random geographies for the map.
    //Make actual geography generation later.
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
