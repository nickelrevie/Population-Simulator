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

    private static ResourceDeposit[] forestResources =     { new ResourceDeposit(Resource.Type.Wood, 3),      new ResourceDeposit(Resource.Type.Animals, 2),     new ResourceDeposit(Resource.Type.Vegetables, 1)   };
    private static ResourceDeposit[] grasslandResources =  { new ResourceDeposit(Resource.Type.Grains, 3),    new ResourceDeposit(Resource.Type.Animals, 1),                                                        };
    private static ResourceDeposit[] swampResources =      { new ResourceDeposit(Resource.Type.Animals, 1),   new ResourceDeposit(Resource.Type.Vegetables, 1)                                                      };
    private static ResourceDeposit[] mountainResources =   { new ResourceDeposit(Resource.Type.Stone, 2),     new ResourceDeposit(Resource.Type.Metals, 1)                                                          };
    private static ResourceDeposit[] tundraResources =     { new ResourceDeposit(Resource.Type.Animals, 1),   new ResourceDeposit(Resource.Type.Vegetables, 1)                                                      };
    private static ResourceDeposit[] waterResources =      { new ResourceDeposit(Resource.Type.SeaAnimals, 1)                                                                                                       };
    private static ResourceDeposit[] desertResources =     {                                                                                                                                                        };

    private static ResourceDeposit[][] baseResourceList = {forestResources, grasslandResources, swampResources, mountainResources, tundraResources, waterResources, desertResources};

    public static Geography CreateGeography(Geography.Biome biome)
    {
        Geography newGeography = new Geography(biome, baseResourceList[(int)biome], spriteList[(int)biome]);
        AddRandomResourcesToGeography(newGeography);
        return newGeography;
    }

    private static void AddRandomResourcesToGeography(Geography geography)
    {
        List<ResourceDeposit> resourceDepositsToAdd = new List<ResourceDeposit>();
        if (geography.GetBiome() == Geography.Biome.water) //
        {
            int spawnChance = 49;
            if (spawnChance < Random.Range(0, 100))
            {
                int yield = Random.Range(1, 3);
                if (yield > 1)
                {
                    yield -= 1;
                }
                resourceDepositsToAdd.Add(new ResourceDeposit(Resource.Type.SeaAnimals, yield));
                geography.AddResourceDeposits(resourceDepositsToAdd);
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
                    resourceDepositsToAdd.Add(new ResourceDeposit(resourceType, yield));
                    spawnChance /= 2;
                }
            }
            if (resourceDepositsToAdd.Count > 0)
            {
                geography.AddResourceDeposits(resourceDepositsToAdd);
            } 
        }
    }
}
