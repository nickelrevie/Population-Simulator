using UnityEngine;
using System.Collections;

public static class GeographyManager {

    public enum geographyType
    {
        forest = 0,
        grassland = 1,
        swamp = 2,
        mountain = 3,
        tundra = 4,
        water = 5,
        desert = 6
    }

    private static Resource.resourceType[] forestResources    =       { Resource.resourceType.wood      , Resource.resourceType.animals, Resource.resourceType.vegetables   };
    private static Resource.resourceType[] grasslandResources =       { Resource.resourceType.fruit     , Resource.resourceType.vegetables                                  };
    private static Resource.resourceType[] swampResources     =       { Resource.resourceType.vegetables, Resource.resourceType.animals                                     };
    private static Resource.resourceType[] mountainResources  =       { Resource.resourceType.stone     , Resource.resourceType.metals                                      };
    private static Resource.resourceType[] tundraResources    =       { Resource.resourceType.animals                                                                       };
    private static Resource.resourceType[] waterResources     =       { Resource.resourceType.seaAnimals                                                                    };
    private static Resource.resourceType[] desertResources    =       {                                                                                                     };

    private static int[] forestBaseYields       = {3, 2, 1  };
    private static int[] grasslandBaseYields    = {2, 2     };
    private static int[] swampBaseYields        = {2, 1     };
    private static int[] mountainBaseYields     = {3, 2     };
    private static int[] tundraBaseYields       = {1        };
    private static int[] waterBaseYields        = {2        };
    private static int[] desertBaseYields       = {         };

    private static Resource.resourceType[][] geographyTypeBaseResources = {forestResources, grasslandResources, swampResources, mountainResources, tundraResources, waterResources, desertResources};
    private static int[][] geographyTypeBaseResourceYields = {forestBaseYields, grasslandBaseYields, swampBaseYields, mountainBaseYields, tundraBaseYields, waterBaseYields, desertBaseYields};

    private static Resource[][] baseResourceList = createResourceList();

    private static Resource[][] createResourceList()
    {
        Resource[][] resourceList = new Resource[geographyTypeBaseResources.Length][];
        for (int i = 0; i < geographyTypeBaseResources.Length; i++)
        {
            resourceList[i] = new Resource[geographyTypeBaseResources[i].Length];
            for (int k = 0; k < geographyTypeBaseResources[i].Length; k++)
            {
                resourceList[i][k] = new Resource(geographyTypeBaseResources[i][k], geographyTypeBaseResourceYields[i][k]);
            }
        }
        return resourceList;
    }

    private static Resource[] getBaseResourceList(int geographyType)
    {
        return baseResourceList[geographyType];
    }

    public static Geography createGeography(geographyType geoType)
    {
        return new Geography(geoType, getBaseResourceList((int)geoType));
    }
}
