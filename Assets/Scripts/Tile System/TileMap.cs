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

    //Checks if the location requested is a valid location in the tile map.
    public bool IsValidLocation(int[] location)
    {
        //location[0] is the X coordinate, location[1] is the Y coordinate.
        if (location[0] < 0 ||              //If the x is less than 0
            location[1] < 0 ||              //If the y is less than 0
            location[0] > mapWidth ||       //If the x is greater than the map width
            location[1] > mapHeight)        //If the y is greater than the map height
        {
            return false;
        }

        return true;    //Returns true if there are no problems with the tile location.
    }

    //Returns the tile at the associated x and y location.
    public Tile GetTile(int[] location)
    {
        return tileMap[location[0], location[1]].GetComponent<Tile>();
    }
}
