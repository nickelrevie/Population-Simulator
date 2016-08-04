using UnityEngine;
using System.Collections;

public class TileManager: MonoBehaviour {

    public GameObject tile_prefab;
    public GameObject[,] tile_map;

    private int map_height = 40;
    private int map_width = 40;

	// Use this for initialization
	void Start ()
    {
        CreateTileMap();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void CreateTileMap()
    {
        tile_map = new GameObject[map_height, map_width];
        for (int i = 0; i < map_height; i++)
        {
            for (int k = 0; k < map_width; k++)
            {
                tile_map[i,k] = GameObject.Instantiate(tile_prefab, 
                    new Vector3(3.5f * k + 1.75f * (i%2), 3.075f * i, 0), 
                    Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }
    }
}
