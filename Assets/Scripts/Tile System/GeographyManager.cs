using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GeographyManager{

    //The sprite images for each geography type
    private static Sprite forestSprite      =   Resources.Load<Sprite>("Sprites/TileSprites/TileForest"     );
    private static Sprite grasslandSprite   =   Resources.Load<Sprite>("Sprites/TileSprites/TileGrassland"  );
    private static Sprite swampSprite       =   Resources.Load<Sprite>("Sprites/TileSprites/TileSwamp"      );
    private static Sprite mountainSprite    =   Resources.Load<Sprite>("Sprites/TileSprites/TileMountain"   );
    private static Sprite tundraSprite      =   Resources.Load<Sprite>("Sprites/TileSprites/TileTundra"     );
    private static Sprite waterSprite       =   Resources.Load<Sprite>("Sprites/TileSprites/TileWater"      );
    private static Sprite desertSprite      =   Resources.Load<Sprite>("Sprites/TileSprites/TileDesert"     );

    //Array of all the sprites
    private static Sprite[] spriteList = {forestSprite, grasslandSprite, swampSprite, mountainSprite, tundraSprite, waterSprite, desertSprite};

    //The base resource values for each geography type.
    private static ResourceDeposit[] forestResources =     { new ResourceDeposit(Resource.Type.Wood, 3),      new ResourceDeposit(Resource.Type.Animals, 2),     new ResourceDeposit(Resource.Type.Vegetables, 1)   };
    private static ResourceDeposit[] grasslandResources =  { new ResourceDeposit(Resource.Type.Grains, 3),    new ResourceDeposit(Resource.Type.Animals, 1),                                                        };
    private static ResourceDeposit[] swampResources =      { new ResourceDeposit(Resource.Type.Animals, 1),   new ResourceDeposit(Resource.Type.Vegetables, 1)                                                      };
    private static ResourceDeposit[] mountainResources =   { new ResourceDeposit(Resource.Type.Stone, 2),     new ResourceDeposit(Resource.Type.Metals, 1)                                                          };
    private static ResourceDeposit[] tundraResources =     { new ResourceDeposit(Resource.Type.Animals, 1),   new ResourceDeposit(Resource.Type.Vegetables, 1)                                                      };
    private static ResourceDeposit[] waterResources =      { new ResourceDeposit(Resource.Type.SeaAnimals, 1)                                                                                                       };
    private static ResourceDeposit[] desertResources =     {                                                                                                                                                        };

    //Array of the resource values
    private static ResourceDeposit[][] baseResourceList = {forestResources, grasslandResources, swampResources, mountainResources, tundraResources, waterResources, desertResources};

    //Creates a geography object based on the desired biome and returns it.
    public static Geography CreateGeography(Geography.Biome biome)
    {
        Geography newGeography = new Geography(biome, baseResourceList[(int)biome], spriteList[(int)biome]);
        AddRandomResourcesToGeography(newGeography); //Adds random bonus resources.
        return newGeography;
    }

    //Adds random resources to the geography.
    private static void AddRandomResourcesToGeography(Geography geography)
    {
        List<ResourceDeposit> resourceDepositsToAdd = new List<ResourceDeposit>();
        if (geography.GetBiome() == Geography.Biome.water) //If the biome is a water biome, there is a 50% chance of adding a sea animals deposit.
        {
            int spawnChance = 49; //There will be a 50% chance of spawning. 0-49, 50-99.
            if (spawnChance > Random.Range(0, 100))
            {
                int yield = Random.Range(1, 3); //Creates a yield of either 1 or 2.
                resourceDepositsToAdd.Add(new ResourceDeposit(Resource.Type.SeaAnimals, yield));
                geography.AddResourceDeposits(resourceDepositsToAdd);
            }
        }
        else //Spawns any type of resource on any other tile.
        {
            int spawnChance = 60; //60% chance of spwaning any natural resource except sea animals
            for (int i = 0; i < 3; i++) //There can be up to three different bonus resources added to a tile.
            {
                if (spawnChance > Random.Range(0, 100))
                {
                    Resource.Type resourceType = (Resource.Type)Random.Range(0, 9); //Sea animals are in position 9 so it cannot be chosen. Random.range(0,x) returns numbers from 0 to x-1.
                    int yield = Random.Range(1, 3); //The yield will either be one or two.
                    resourceDepositsToAdd.Add(new ResourceDeposit(resourceType, yield));
                    spawnChance /= 2; //The spawn chance of another deposit is cut in half.
                }
            }
            if (resourceDepositsToAdd.Count > 0) //If there are any bonus resources to add to a tile, call the add resource deposits function.
            {
                geography.AddResourceDeposits(resourceDepositsToAdd);
            } 
        }
    }
}
