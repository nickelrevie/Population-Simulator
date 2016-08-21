using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Geography
{

    public enum Biome
    {
        forest = 0,
        grassland = 1,
        swamp = 2,
        mountain = 3,
        tundra = 4,
        water = 5,
        desert = 6
    }

    private Sprite sprite;
    private List<Resource> resourceList;
    private Biome biome;

    public Geography(Biome _biome, Resource[] baseResourceList, Sprite _sprite)
    {
        resourceList = new List<Resource>();
        if (baseResourceList.Length != 0)
        {
            foreach (Resource res in baseResourceList)
            {
                resourceList.Add(res);
            }
        }
        biome = _biome;
        sprite = _sprite;
    }

    public Biome getBiome()
    {
        return biome;
    }

    public Sprite getSprite()
    {
        return sprite;    
    }

    public List<Resource> getResourceList()
    {
        return resourceList;
    }

    public void addResources(List<Resource> newResources)
    {
        foreach (Resource newRes in newResources)
        {
            if (resourceList.Count != 0)
            {
                List<Resource> resToAdd = new List<Resource>();
                foreach (Resource res in resourceList)
                {
                    if (newRes.getType() == (res.getType()))
                    {
                        res.increaseYield(newRes.getYield());
                    }
                    else
                    {
                        resToAdd.Add(newRes);
                    }
                }
                foreach (Resource res in resToAdd)
                {
                    resourceList.Add(res);
                }
            }
            else
            {
                foreach (Resource res in newResources)
                {
                    resourceList.Add(res);
                }
            }
        }
    }
}
