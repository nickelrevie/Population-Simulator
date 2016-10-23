using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Settlement : MonoBehaviour {

    //The Settlement Tile Types. Revisit to make districts a new class and have the center be a City
    public enum Class
    {
        Camp,               //Camps are one tile and have a simple government, citizens can create a village by accumulating wood.
        Village,            //Villages are one tile and have basic government.
        Town,               //Towns are one tile and have a basic government, but are larger.
        Center,             //Center tiles are the center of a city and have a more complex governemt. Cities can have more than one tile
        District            //Districts are the remaining tiles of a city.
    }

    private GameObject hostTile;                            //The tile game object that this settlement is located on.
    private List<Citizen> population = new List<Citizen>(); //List of the citizens living in the settlement.
    private Class settlementClass;                          //The settlement class of the settlement.
    private List<House> housing = new List<House>();        //The list of housing buildings in the settlement.
    private int totalResidentLimit = 0;                     //The total amount of people the housing can accomodate.

    //List of all the resource types and their yields that are currently stockpiled by the city. 0-9 are natural, 10-15 are developed resources.
    private static Resource[] stockpiledResources =
    {
        new Resource((Resource.Type) 0, 0),
        new Resource((Resource.Type) 1, 0),
        new Resource((Resource.Type) 2, 0),
        new Resource((Resource.Type) 3, 0),
        new Resource((Resource.Type) 4, 0),
        new Resource((Resource.Type) 5, 0),
        new Resource((Resource.Type) 6, 0),
        new Resource((Resource.Type) 7, 0),
        new Resource((Resource.Type) 8, 0),
        new Resource((Resource.Type) 9, 0),
        new Resource((Resource.Type)10, 0),
        new Resource((Resource.Type)11, 0),
        new Resource((Resource.Type)12, 0),
        new Resource((Resource.Type)13, 0),
        new Resource((Resource.Type)14, 0),
        new Resource((Resource.Type)15, 0)
    };

    
	// Use this for initialization
	void Start () //When a settlement is created and attached to a game object it will start out as a camp and set the tile it is being attached to.
    {
        settlementClass = Class.Camp;
        hostTile = gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //Updates the settlement every time step.
    void UpdateSettlement()
    {
        EvaluateSettlementClass(); //Start off by checking if the settlement is large enough to upgrade to a larger settlement class.
    }

    //SETTLEMENT UPGRADE SYSTEM
    //Check if the settlement is large enough to upgrade to a larger settlement class.
    void EvaluateSettlementClass()
    {
        Class newSettlementClass = settlementClass; //Set it to the current settlement class so it's initialized.
        switch(settlementClass)
        {
            case Class.Camp:
                if (UseStockpiledResource(Resource.Type.Wood, 500) == true)
                {
                    newSettlementClass = Class.Village;
                }
                break;
            case Class.Village:
                if (UseStockpiledResource(Resource.Type.Wood, 5000) == true && population.Count > 10)
                {
                    newSettlementClass = Class.Town;
                }
                break;
            case Class.Town:
                break;
            default: break;
        }
        SetSettlementClass(newSettlementClass);
    }

    //Sets the class and changes the settlement graphic.
    void SetSettlementClass(Class newClass)
    {
        settlementClass = newClass;
        //Insert change graphic code for new settlement class. Settlement graphics not implemented yet.
    }

    //SETTLEMENT STOCKPILE AND RESOURCE SYSTEM

    //Tells all of the citizens in the settlement to work each resource that they are assigned to.
    void WorkTile()
    {
        foreach(Citizen worker in population)
        {
            worker.CollectResourcesFromDeposit();
        }
    }

    //Adds resources to the stockpile array.
    void AddResourceToStockpile(Resource resource)
    {
        stockpiledResources[(int)resource.GetResourceType()].IncreaseYield(resource.GetYield());
    }

    //Attempts to consume the desired amount of resources. If it can, it will consume those resources and return true. If not, it will return false.
    bool UseStockpiledResource(Resource.Type type, int amount)
    {
        Resource resource = stockpiledResources[(int)type];
        if (resource.GetYield() >= amount)
        {
            resource.DecreaseYield(amount);
            return true;
        }
        return false;
    }

    //POPULATION MANAGEMENT

    //Adds the inhabitant to the settlement and assigns a job to it. If there is not enough housing, it will not accept a new inhabitant.
    public bool AddInhabitant(Citizen newInhabitant)
    {
        if (population.Count <= totalResidentLimit)
        {
            population.Add(newInhabitant);
            AssignJobToInhabitant(newInhabitant);
            return true;
        }
        return false;
    }

    //Assigns a job to an inhabitant. Job means assigning them to work a resource deposit on the tile.
    void AssignJobToInhabitant(Citizen unemployedInhabitant)
    {
        //Assign a job
    }

    //Returns the total number of residents able to live in the settlement.
    void CheckHousingLimit()
    {
        totalResidentLimit = 0;
        foreach (House residence in housing)
        {
            totalResidentLimit += residence.GetResidenceLimit();
        }
    }
}
