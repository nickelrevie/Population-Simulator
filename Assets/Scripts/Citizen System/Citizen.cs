using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Citizen : MonoBehaviour {

    private int age = 0;    //The age of the citizen.
    private Tile location;  //The tile the Citizen is currently located on.

    private Settlement homeSettlement;  //The settlement the citizen is currently living in.
    private House homeBuilding;         //The building the citizen is currently living in.

    private int wealth = 0;
    private int happiness = 0;  //0-99. Happy and wealthy citizens are less likely to leave or rebel or attack people of differing values.
    private int food = 0;       //Decreases happiness and health if the food value is at zero.
    private int health = 0;     //0-99. 49 is healthy. Influences resource skill. The citizen dies if its health reaches 0.
    private int actions = 1;    //reduces by one each time an action is done. Building a house, workshop etc

    private List<Citizen> enemies = new List<Citizen>();
    private List<Citizen> allies = new List<Citizen>();

    //Values go from 0-99
    private int numberOfTraits = 10;
    private int faith = 0;              //Faith provides a happiness benefit when there are more of a similar faith value nearby.
    private int honor = 0;              //Honor determines whether they will attempt to attack enemies.
    private int determination = 0;      //Resists happiness decline when resources are scarce. Influences resource skill.
    private int loyalty = 0;            //Determines whether a citizen is more likely to rebel or not rebel against their own allies.
    private int tolerance = 0;          //A higher value raises happiness when there are differing values and lower values lower happiness when there are differing values. Also affects when Citizens get placed as an ally or enemy.
    private int creativity = 0;         //Influences resource skill. Higher values also have a higher chance of moving to new areas.
    private int compassion = 0;         //A higher value increases food and wealth distribution
    private int resourcefulness = 0;    //Increases wealth when low on food. Increases food when low on wealth. Higher values raise the limits at which this occurs and the effectiveness.
    private int virtue = 0;             //Higher virtue are less likely to be hostile to foreign values.
    private int wisdom = 0;             //Higher wisdom of increases the resource skill of all allied Citizens slightly.

    private ResourceDeposit resourceWorked;
    private int resourceSkill = 0;      //0-100. Higher values will increase the amount of resource made per time step.
    
    //Creates a new citizen on the chosen tile, if created by a parent, then it should be on the same tile as the parent.
    public Citizen(Tile _location, Citizen parent, bool hasParents)
    {
        GenerateTraits(hasParents, parent);
        location = _location;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* 
     * REPRODUCTION METHODS
     */

    //Creates a new citizen bases off of the traits of the parent.
    void Reproduce()
    {
        Citizen newCitizen = new Citizen(location, this, true);
    }

    //Generates the traits for the citizen. If the citizen has parents it will reroll a few of the traits. Otherwise it will just roll random values for them.
    void GenerateTraits(bool hasParents, Citizen parent)
    {
        if (hasParents)
        {
            ImportParentTraits(parent);
            RerollRandomTraits();
        }
        else
        {
            RollStartingTraits();   
        }
    }

    //Imports the traits
    void ImportParentTraits(Citizen parent)
    {
        faith           = parent.faith;
        honor           = parent.honor;
        determination   = parent.determination;
        loyalty         = parent.loyalty;
        tolerance       = parent.tolerance;
        creativity      = parent.creativity;
        compassion      = parent.compassion;
        resourcefulness = parent.resourcefulness;
        virtue          = parent.virtue;
        wisdom          = parent.wisdom;
    }

    //Rerolls a random number of traits. 1-3.
    void RerollRandomTraits()
    {
        int traitsToChange = Random.Range(1, 4);
        List<int> traitsChanged = new List<int>();
        for (int i = 0; i < traitsToChange; i++)
        {
            int trait = Random.Range(0, numberOfTraits);
            while (traitsChanged.Contains(trait))
            {
                trait = Random.Range(0, numberOfTraits);
            }
            traitsChanged.Add(trait);
            RollTrait(trait);
        }
    }

    //Just rolls random numbers for all the traits.
    void RollStartingTraits()
    {
        for (int i = 0; i < numberOfTraits; i++)
        {
            RollTrait(i);
        }
    }

    //Method that actually rolls the traits. Used in both types of reproduction.
    void RollTrait(int traitNumber)
    {
        switch (traitNumber)
        {
            case 0:
                faith = Random.Range(0, 100);
                break;
            case 1:
                honor = Random.Range(0, 100);
                break;
            case 2:
                determination = Random.Range(0, 100);
                break;
            case 3:
                loyalty = Random.Range(0, 100);
                break;
            case 4:
                tolerance = Random.Range(0, 100);
                break;
            case 5:
                creativity = Random.Range(0, 100);
                break;
            case 6:
                compassion = Random.Range(0, 100);
                break;
            case 7:
                resourcefulness = Random.Range(0, 100);
                break;
            case 8:
                virtue = Random.Range(0, 100);
                break;
            case 9:
                wisdom = Random.Range(0, 100);
                break;
            default:
                break;
        }
    }

    //MOVEMENT METHODS 

    //Move the citizen to a new tile. It would have to check if there is a settlement so that it can attempt to live there for the turn. The citizen will then decide if it wants to stay and inhabit it for a period of time.
    
    void MoveToNewTile(Tile destination)
    {
        //Tells the tile there is another person on the location.
        //The destination shoudl always be a bordering tile unless the citizen can move multiple times.
        location = destination;
        location.AddInhabitant(this);
        if (CheckSettlementStatus())
        {

        }
        else
        {

        }
    }

    //WHAT HAPPENS AFTER THE MOVMENT METHODS

    //If settlement does not exist, create one
    //If one does not, check if it can inhabit the space
    //If not, move to another space in the settlement (if possible)
    //Otherwise move to nearby space that seems habitable
    bool CheckSettlementStatus()
    {
        return location.GetHasSsettlement();
    }

    //RESOURCE COLLECTION METHODS

    //Collects resources from the deposit they are assigned to.
    public Resource CollectResourcesFromDeposit()
    {
        return resourceWorked.GatherResource(this);
    }
}
