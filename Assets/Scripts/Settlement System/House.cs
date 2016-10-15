using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House
{
    //The types of housing that can exist.
    public enum HousingType
    {
        Tent,
        House1,
        House2,
        House3,
        Apartment4,
        Apartment8
    }

    private List<Citizen> residents = new List<Citizen>(); //The residents that live in the house object.
    private HousingType housing; //The type of house.

    //Constructor of the house object.
    public House(Settlement location)
    {

    }

    //Adds a resident to the house object unless it cannot house more.
    public bool AddResident(Citizen resident)
    {
        if (CanHouseMore()) //Checks if the housing type can house more people.
        {
            residents.Add(resident);
            return true;
        }
        else return false;
    }

    //Removes the resident from occupying this house object.
    public void RemoveResident(Citizen resident)
    {
        residents.Remove(resident);
    }

    //Checks if the housing type can house more people.
    public bool CanHouseMore()
    {
        if (residents.Count >= GetResidenceLimit() && GetResidenceLimit() != 0) //Calls the GetResidenceLimit method and checks if it doesn't return 0.
        {
            return true;
        }
        return false;
    }

    //Each housing type can have a maximum number of people it holds. This holds those values.
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
            default:                        return 0; //Returns zero when there is an invalid input type.
        }
    } 

}
