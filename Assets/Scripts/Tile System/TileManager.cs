using UnityEngine;
using System.Collections;

public class TileManager: MonoBehaviour {

    private TileMap tileMap;
    
    // Use this for initialization
    void Start ()
    {
        MapGenerator mapGenerator = new MapGenerator();
        tileMap = mapGenerator.CreateTileMap();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
