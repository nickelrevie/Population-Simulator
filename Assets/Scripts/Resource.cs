using UnityEngine;
using System.Collections;

public class Resource{

    public enum Type
    {
        //Natural
        Animals = 0,
        Vegetables = 1,
        Fruit = 2,
        Grains = 3,
        Metals = 4,
        RareMetals = 5,
        Stone = 6,
        Gems = 7,
        Wood = 8,
        SeaAnimals = 9,

        //Developed
        Clothing = 10,
        Ceramics = 11,
        Woodwork = 12,
        Metalwork = 13,
        Masonry = 14,
        Jewelry = 15
    }

    private Type type;
    private int yield;

    public Resource(Type _type, int _yield)
    {
        type = _type;
        yield = _yield;
    }

    public void increaseYield(int _yield)
    {
        yield += _yield;
    }

    public int getYield()
    {
        return yield;
    }

    public Type getType()
    {
        return type;
    }
}
