using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Citizen
{
    //AI HUB
    private Brain brain; //The brain controls all the decision making for the citizen.


    private Tile location;  //The tile the Citizen is currently located on.

    //Settlement variables
    private Settlement homeSettlement;  //The settlement the citizen is currently living in.
    private House homeBuilding;         //The building the citizen is currently living in.

    //Citizen physical health variables
    private int age         =     0;    //The age of the citizen.
    private int health      =    50;    //The physical health of the citizen. 0-99. 49 is healthy. Influences resource skill. The citizen dies if its health reaches 0. Age decreases maximum health.
    private int fertility   =    20;    //The chance to spawn another person per turn. 0-20.
    private bool hungry     = false;    //The amount of food the citizen posesses. Decreases happiness and health if the food value is at zero.

    //Trait genetic code of the citizen. These affect the behavior of the Citizen. Go from 0-99. Some are not applicable until more AI systems are implemented.
    private GeneticCode geneticCode;

    //Resource variables
    private ResourceDeposit resourceWorked; //The resource that the Citizen is currently working.
    private int resourceSkill = 0;          //The skill that the citizen has with working the resource. 0-100. Higher values will increase the amount of resource made per time step.

    //Creates a new citizen and it should be on the same tile as the parent.
    public Citizen(Citizen parent)
    { 
        geneticCode = new GeneticCode(parent.geneticCode);
        brain = new Brain(this, geneticCode);
        location = parent.location;
    }

    //Creating a new citizen without a parent.
    public Citizen(Tile _location)
    {
        geneticCode = new GeneticCode();
        brain = new Brain(this, geneticCode);
        location = _location;
    }

    //Tells the citizen to do actions this next time step.
    public void UpdateCitizen()
    {
        Age(); //Ages the citizen.
        if (CanReproduce()) //Checks if it can reproduce and does if it returns true;
        {
            Reproduce();
        }
        //Checks if it will move. If there is a nearby city, it will try to move there. If there is low happiness it will leave a city and find a new one or found a new one.
    }

    //Ages the citizen.
    void Age() //Check to see if using same as variable name is misleading.
    {
        age++;              //Increases age by one.
        health -= 2;        //Reduces health due to aging.
        if (age > 10)
        {
            fertility -= 1; //Reduces fertility by 1. When over the age of 10.
        }
    }

    //Consume Food
    void ConsumeFood()
    {

    }

    void HealthCheck()
    {
        if (health <= 0)
        {

        }
    }

    //REPRODUCTION METHODS
    
    bool CanReproduce()
    {
        return (age > 10 && fertility > Random.Range(0, 100)); //Is an adult age. Also does a fertility check. Fertility is the % chance of reproduction happening.
    }

    //Creates a new citizen bases off of the traits of the parent.
    void Reproduce()
    {
        Citizen newCitizen = new Citizen(this);
    }

    //MOVEMENT METHODS 

    //Move the citizen to a new tile. It would have to check if there is a settlement so that it can attempt to live there for the turn. The citizen will then decide if it wants to stay and inhabit it for a period of time.   
    public void MoveToNewTile(Tile destination)
    {
        //Tells the tile there is another person on the location.
        //The destination should always be a bordering tile unless the citizen can move multiple times.
        location = destination;
        location.AddInhabitant(this);
    }

    //Scans the nearby tiles and returns them.
    public List<Tile> GetNearbyTiles()
    {
        List<Tile> nearbyTiles = new List<Tile>();                      //Creates an empty list of tiles. This list is variable in size.
        TileMap map = location.GetTileMap();                            //Gets the tile map.
        int[] currentLocation = location.GetLocation();                 //Gets the location array from the home tile.

        //Adds all the tiles that border the current tile. Make a more complex 
        AddToNearbyTiles(map, nearbyTiles, new int[] { currentLocation[0] - 1, currentLocation[1]    });    //Gets the tile to the          left    of the location.
        AddToNearbyTiles(map, nearbyTiles, new int[] { currentLocation[0]    , currentLocation[1] - 1});    //Gets the tile to the  bottom  left    of the location.
        AddToNearbyTiles(map, nearbyTiles, new int[] { currentLocation[0]    , currentLocation[1] + 1});    //Gets the tile to the  top     left    of the location.
        AddToNearbyTiles(map, nearbyTiles, new int[] { currentLocation[0] + 1, currentLocation[1]    });    //Gets the tile to the          right   of the location.
        AddToNearbyTiles(map, nearbyTiles, new int[] { currentLocation[0] + 1, currentLocation[1] - 1});    //Gets the tile to the  bottom  right   of the location.
        AddToNearbyTiles(map, nearbyTiles, new int[] { currentLocation[0] + 1, currentLocation[1] + 1});    //Gets the tile to the  top     right   of the location.

        return nearbyTiles;
    }

    //Adds a tile to the nearby tiles list if it is a valid location on the world.
    void AddToNearbyTiles(TileMap map, List<Tile> nearbyTiles, int[] location)
    {
        if (map.IsValidLocation(location))
        {
            nearbyTiles.Add(map.GetTile(location));
        }
    }


    //WHAT HAPPENS AFTER THE MOVMENT METHODS

    //If settlement does not exist, create one
    //If one does not, check if it can inhabit the space
    //If not, move to another space in the settlement (if possible)
    //Otherwise move to nearby space that seems habitable
    public bool CheckSettlementStatus()
    {
        return location.HasSettlement();
    }

    //RESOURCE COLLECTION METHODS
    //Collects resources from the deposit they are assigned to.
    //Add resource skill affecting this.
    public Resource CollectResourcesFromDeposit()
    {
        return resourceWorked.GatherResource(this);
    }

    //GET METHODS
    public Tile GetLocation()
    {
        return location;
    }
}
