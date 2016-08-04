using UnityEngine;
using System.Collections;

public class Resource{

    public enum resourceType
    {
        //Natural
        animals,
        vegetables,
        fruit,
        grains,
        seaAnimals,
        metals,
        rareMetals,
        stone,
        gems,
        wood,

        //Developed
        clothing,
        ceramics,
        woodwork,
        metalwork,
        masonry,
        jewelry
    }

    private resourceType type;
    private int yield;

    public Resource(resourceType _type, int _yield)
    {
        type = _type;
        yield = _yield;
    }
}
