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
    private List<ResourceDeposit> resourceDeposits;
    private Biome biome;

    public Geography(Biome _biome, ResourceDeposit[] baseResourceDeposits, Sprite _sprite)
    {
        resourceDeposits = new List<ResourceDeposit>();
        if (baseResourceDeposits.Length != 0)
        {
            foreach (ResourceDeposit resDeposit in baseResourceDeposits)
            {
                resourceDeposits.Add(resDeposit);
            }
        }
        biome = _biome;
        sprite = _sprite;
    }

    public Biome GetBiome()
    {
        return biome;
    }

    public Sprite GetSprite()
    {
        return sprite;    
    }

    public List<ResourceDeposit> GetResourceDeposits()
    {
        return resourceDeposits;
    }

    public void AddResourceDeposits(List<ResourceDeposit> newResourceDeposits)
    {
        foreach (ResourceDeposit newResDeposit in newResourceDeposits)
        {
            if (resourceDeposits.Count != 0)
            {
                List<ResourceDeposit> resDepositToAdd = new List<ResourceDeposit>();
                foreach (ResourceDeposit resDeposit in resourceDeposits)
                {
                    if (newResDeposit.GetDepositType() == (resDeposit.GetDepositType()))
                    {
                        resDeposit.IncreaseDepositSize(newResDeposit.GetDepositSize());
                    }
                    else
                    {
                        resDepositToAdd.Add(newResDeposit);
                    }
                }
                foreach (ResourceDeposit resDeposit in resDepositToAdd)
                {
                    resourceDeposits.Add(resDeposit);
                }
            }
            else
            {
                foreach (ResourceDeposit resDeposit in newResourceDeposits)
                {
                    resourceDeposits.Add(resDeposit);
                }
            }
        }
    }
}
