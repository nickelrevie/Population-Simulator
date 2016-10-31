using UnityEngine;
using System.Collections;

public class Resource{

    public enum Type
    {
        //Natural
        Animals,
        Vegetables,
        Fruit,
        Grains,
        Metals,
        RareMetals,
        Stone,
        Gems,
        Wood,
        SeaAnimals,

        //Developed
        Clothing,
        Ceramics,
        Woodwork,
        Metalwork,
        Masonry,
        Jewelry
    }

    private Type type; //The type of the resource
    private int yield; //The amount of resource in the collection.

    //Constructor for the resource object
    public Resource(Type _type, int _yield)
    {
        type = _type;
        yield = _yield;
    }

    //Increases the yield on the resource object.
    public void IncreaseYield(int _yield)
    {
        yield += _yield;
    }

    //Decreases the yield of the resource object.
    public void DecreaseYield(int _yield)
    {
        yield -= _yield;
    }

    //Returns the yield of the resource.
    public int GetYield()
    {
        return yield;
    }

    //Returns the resource type of the resource object.
    public Type GetResourceType()
    {
        return type;
    }
}
