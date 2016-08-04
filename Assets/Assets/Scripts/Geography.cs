using UnityEngine;
using System.Collections;


public class Geography {

    private Resource[] baseResourceList;
    private GeographyManager.geographyType type;

    public Geography(GeographyManager.geographyType _type, Resource[] _baseResourceList)
    {
        baseResourceList = _baseResourceList;
        type = _type;
    }

    void setGeography(string geographyType, Tile targetTile)
    {
        
    }

    void generateGeographicResources()
    {

    }
}
