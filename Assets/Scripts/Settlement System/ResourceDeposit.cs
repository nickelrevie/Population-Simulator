using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceDeposit
{

    private Resource.Type type;
    private int size;
    private bool highYield = false;
    private int yield = 50;
    private List<Citizen> citizensWorking;

    public ResourceDeposit(Resource.Type _type, int _size)
    {
        type = _type;
        size = _size;
        int highYieldNumber = Random.Range(0, 100);
        if (highYieldNumber < 10)
        {
            highYield = true;
            yield += 20;
        }
    }

    public Resource GatherResource(Citizen gatherer)
    {
        return new Resource(type, yield);
    }

    public void IncreaseDepositSize(int _size)
    {
        size += _size;
    }

    public Resource.Type GetDepositType()
    {
        return type;
    }

    public int GetDepositSize()
    {
        return size;
    }
}
