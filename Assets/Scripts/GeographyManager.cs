using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GeographyManager{

    private static Sprite forestSprite      =   Resources.Load<Sprite>("Sprites/TileSprites/TileForest"     );
    private static Sprite grasslandSprite   =   Resources.Load<Sprite>("Sprites/TileSprites/TileGrassland"  );
    private static Sprite swampSprite       =   Resources.Load<Sprite>("Sprites/TileSprites/TileSwamp"      );
    private static Sprite mountainSprite    =   Resources.Load<Sprite>("Sprites/TileSprites/TileMountain"   );
    private static Sprite tundraSprite      =   Resources.Load<Sprite>("Sprites/TileSprites/TileTundra"     );
    private static Sprite waterSprite       =   Resources.Load<Sprite>("Sprites/TileSprites/TileWater"      );
    private static Sprite desertSprite      =   Resources.Load<Sprite>("Sprites/TileSprites/TileDesert"     );

    private static Sprite[] spriteList = {forestSprite, grasslandSprite, swampSprite, mountainSprite, tundraSprite, waterSprite, desertSprite};

    private static Resource[] forestResources =     { new Resource(Resource.Type.Wood, 3),      new Resource(Resource.Type.Animals, 2),     new Resource(Resource.Type.Vegetables, 1)   };
    private static Resource[] grasslandResources =  { new Resource(Resource.Type.Grains, 3),    new Resource(Resource.Type.Animals, 1),                                                 };
    private static Resource[] swampResources =      { new Resource(Resource.Type.Animals, 1),   new Resource(Resource.Type.Vegetables, 1)                                               };
    private static Resource[] mountainResources =   { new Resource(Resource.Type.Stone, 2),     new Resource(Resource.Type.Metals, 1)                                                   };
    private static Resource[] tundraResources =     { new Resource(Resource.Type.Animals, 1),   new Resource(Resource.Type.Vegetables, 1)                                               };
    private static Resource[] waterResources =      { new Resource(Resource.Type.SeaAnimals, 1)                                                                                         };
    private static Resource[] desertResources =     {                                                                                                                                   };

    private static Resource[][] baseResourceList = {forestResources, grasslandResources, swampResources, mountainResources, tundraResources, waterResources, desertResources};

    public static Geography createGeography(Geography.Biome biome)
    {
        Geography newGeography = new Geography(biome, baseResourceList[(int)biome], spriteList[(int)biome]);
        addRandomResourcesToGeography(newGeography);
        return newGeography;
    }

    private static void addRandomResourcesToGeography(Geography geography)
    {
        List<Resource> resourcesToAdd = new List<Resource>();
        if (geography.getBiome() == Geography.Biome.water) //
        {
            int spawnChance = 49;
            if (spawnChance < Random.Range(0, 100))
            {
                int yield = Random.Range(1, 3);
                if (yield > 1)
                {
                    yield -= 1;
                }
                resourcesToAdd.Add(new Resource(Resource.Type.SeaAnimals, yield));
                geography.addResources(resourcesToAdd);
            }
        }
        else
        {
            int spawnChance = 60;
            for (int i = 0; i < 3; i++)
            {
                if (spawnChance < Random.Range(0, 100))
                {
                    Resource.Type resourceType = (Resource.Type)Random.Range(0, 9);
                    int yield = Random.Range(1, 3);
                    if (yield > 1)
                    {
                        yield -= 1;
                    }
                    resourcesToAdd.Add(new Resource(resourceType, yield));
                    spawnChance /= 2;
                }
            }
            if (resourcesToAdd.Count > 0)
            {
                geography.addResources(resourcesToAdd);
            } 
        }
    }
}
