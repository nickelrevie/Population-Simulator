using UnityEngine;
using System.Collections;


public class TileMap
{
    private GameObject[,] tileMap;
    private int mapHeight;
    private int mapWidth;

    public void SetMap(GameObject[,] _tileMap)
    {
        tileMap = _tileMap;
        //Doublecheck that these assign the right ones. As in make sure GetLength(0) is height and 1 is width.
        mapHeight = tileMap.GetLength(0);
        mapWidth = tileMap.GetLength(1);
    }

    public GameObject[,] GetMap()
    {
        return tileMap;
    }

    public GameObject GetTile(int[] location)
    {
        return tileMap[location[0], location[1]];
    }
}
