using UnityEngine;
using System.Collections;


public class TileMap
{
    private GameObject[,] tileMap;
    private int mapHeight;
    private int mapWidth;

    //Sets the tilemap array. Set from the map generator. 
    //Should I maybe generate the tile map here and then re-set it after I generate the rest of the map?
    public void SetMap(GameObject[,] _tileMap)
    {
        tileMap = _tileMap;
        //Doublecheck that these assign the right ones. As in make sure GetLength(0) is height and 1 is width.
        mapHeight = tileMap.GetLength(0);
        mapWidth = tileMap.GetLength(1);
    }

    //Returns the map.
    public GameObject[,] GetMap()
    {
        return tileMap;
    }

    //Returns the tile at the associated x and y location.
    public GameObject GetTile(int[] location)
    {
        return tileMap[location[0], location[1]];
    }
}
