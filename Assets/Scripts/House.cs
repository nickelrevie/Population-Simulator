using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House
{
    public enum HousingType
    {
        Tent,
        House1,
        House2,
        House3,
        Apartment4,
        Apartment8
    }
    private List<Citizen> residents = new List<Citizen>();
    private HousingType housing;

    public House(Settlement location)
    {

    }

    public bool SetResident(Citizen resident)
    {
        if (CanHouseMore())
        {
            residents.Add(resident);
            return true;
        }
        else return false;
    }

    public void RemoveResident(Citizen resident)
    {
        residents.Remove(resident);
    }

    public bool CanHouseMore()
    {
        if (residents.Count >= GetResidenceLimit() && GetResidenceLimit() != 0)
        {
            return true;
        }
        return false;
    }

    public int GetResidenceLimit()
    {
        switch (housing)
        {
            case HousingType.Tent:          return 1;
            case HousingType.House1:        return 1;
            case HousingType.House2:        return 2;
            case HousingType.House3:        return 3;
            case HousingType.Apartment4:    return 4;
            case HousingType.Apartment8:    return 8;
            default:                        return 0;
        }
    } 

}
