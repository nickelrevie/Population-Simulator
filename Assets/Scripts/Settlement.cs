using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Settlement : MonoBehaviour {

    public enum Class
    {
        Camp,
        Village,
        Town,
        District,
        Center
    }

    private GameObject hostTile;
    private List<Citizen> population = new List<Citizen>();
    private Class settlementSize;
    private List<House> housing = new List<House>();
    private int totalResidentLimit = 0;

    private static Resource[] stockpiledResources =
    {
        new Resource((Resource.Type)0, 0),
        new Resource((Resource.Type)1, 0),
        new Resource((Resource.Type)2, 0),
        new Resource((Resource.Type)3, 0),
        new Resource((Resource.Type)4, 0),
        new Resource((Resource.Type)5, 0),
        new Resource((Resource.Type)6, 0),
        new Resource((Resource.Type)7, 0),
        new Resource((Resource.Type)8, 0),
        new Resource((Resource.Type)9, 0),
        new Resource((Resource.Type)10, 0),
        new Resource((Resource.Type)11, 0),
        new Resource((Resource.Type)12, 0),
        new Resource((Resource.Type)13, 0),
        new Resource((Resource.Type)14, 0),
        new Resource((Resource.Type)15, 0)
    };

	// Use this for initialization
	void Start ()
    {
        settlementSize = Class.Camp;
        hostTile = this.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void UpdateSettlement()
    {
        EvaluateSettlementClass();
    }

    //SETTLEMENT UPGRADE SYSTEM

    void EvaluateSettlementClass()
    {
        ChangeSettlementClass();
    }

    void ChangeSettlementClass()
    {
        if (settlementSize == Class.Camp)
        {
            if (UseStockpiledResource(Resource.Type.Wood, 500) == true)
            {
                SetSettlementClass(Class.Village);
            }
        }
        else if (settlementSize == Class.Village && population.Count > 10)
        {
            if (UseStockpiledResource(Resource.Type.Wood, 5000) == true)
            {
                SetSettlementClass(Class.Village);
            }
        }
    }

    void SetSettlementClass(Class newClass)
    {
        settlementSize = newClass;
        //insert change graphic for new settlement class
    }

    //SETTLEMENT STOCKPILE AND RESOURCE SYSTEM

    void WorkTile()
    {
        foreach(Citizen worker in population)
        {
            worker.CollectResourcesFromDeposit();
        }
    }

    void AddResourceToStockpile(Resource resource)
    {
        stockpiledResources[(int)resource.GetResourceType()].IncreaseYield(resource.GetYield());
    }

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

    void AssignJobToInhabitant(Citizen unemployedInhabitant)
    {
        //Assign a job
    }

    void CheckHousingLimit()
    {
        totalResidentLimit = 0;
        foreach (House residence in housing)
        {
            totalResidentLimit += residence.GetResidenceLimit();
        }
    }
}
