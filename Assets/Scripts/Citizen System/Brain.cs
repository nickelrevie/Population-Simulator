using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brain
{
    private GeneticCode geneticCode;    //The genetic traits the citizen has.
    private Citizen body;               //The citizen this brain is controlling.

    private bool isMoving;              //Whether the citizen is moving to a destination or is settled on a tile.
    private Tile destination;           //The destination if the citizen is moving.
    private Tile location;              //The current location of the citizen.
    private bool foundBestTile;         //This tell the citizen to stop looking for a better tile to move to.

    private MentalState mentalHealth;   //The current mental state of the citizen.
    private int happiness;              //The happiness of the citizen. 0-99. Happy citizens are less likely to leave or rebel or attack people of differing values.

    public enum MentalState             //Mental health affects the ability of the citizen to perform tasks.
    {
        Ecstatic,   //85-99. Provides 25% boost to production.
        Happy,      //65-84. Provides 10% boost to production.
        Content,    //35-64. Provides no  boost to production.
        Unhappy,    //15-34. Provides a 15% reduction to production.
        Dreadful    //0 -14. Provides a 30% reduction to production.
    }

    //Contructor for the brain.
    public Brain(Citizen _body, GeneticCode DNA)
    {
        body = _body;
        geneticCode = DNA;
        location = body.GetLocation();
    }

    //Processes the information for this time step and makes decisions.
    public void ProcessTimeStep()
    {
        
    }

    //Evaluate the current position and see if the citizen can move to a new tile
    void MoveCheck()
    {
        if (foundBestTile == false && mentalHealth != MentalState.Dreadful)     //A check for why it should move. If it's not on the best tile or the mental state is dreadful, it shouldn't look for another tile.
        {
            List<Tile> nearbyTiles = body.GetNearbyTiles();                     //Gets all bordering tiles.
            destination = GetMostValuableTile(nearbyTiles);                     //Gets the best tile to move to.
            foundBestTile = !IsNewTileABetterDestination(destination, location);
            if (foundBestTile)
            {
                return;
            }
            else
            {
                MoveToTile(destination);
            }
        }
    }

    //Tells the body to move to the tile. Also tells the
    void MoveToTile(Tile destination)
    {
        body.MoveToNewTile(destination);
        location = destination;
        if (body.CheckSettlementStatus())
        {
            //Join the settlement
        }
        else
        {
            //Create a new camp
            location.AddNewSettlement();
        }
    }

    //Iterates through the array and finds the one that is most worth moving to.
    Tile GetMostValuableTile(List<Tile> nearbyTiles)
    { 
        Tile destination = location;      
        //Iterates through every tile in the list, gets the food and building material yields and compares them. If the new tile is higher, it will assign that as the new destination.
        foreach (Tile tile in nearbyTiles)
        {
            if (IsNewTileABetterDestination(tile, destination))
            {
                destination = tile;
            }
        }
        return destination;                                                     //Returns the destination found.
    }

    //Checks if the new tile is better than the old tile in terms of resources.
    bool IsNewTileABetterDestination(Tile newTile, Tile oldTile)
    {
        int destinationFoodYield = YieldOfFoodResource(oldTile);            //The food yield of the destination.
        int destinationBuildingYield = YieldOfBuildingResource(oldTile);    //The building material yield of the destination.

        int newFoodYield = YieldOfFoodResource(newTile);                    //The food yield of the new tile
        int newBuildingYield = YieldOfBuildingResource(newTile);            //The building material yield of the new tile.

        if ((newFoodYield + newBuildingYield) > (destinationFoodYield + destinationBuildingYield))  //If the yields of the new tile is greater than the old tile, then return true;
        {
            return true;
        }

        return false;
    }

    //Iterates through the resource deposits in the tile and returns the number of food resources (animals, grains, vegetables, and fruit).
    int YieldOfFoodResource(Tile tile)
    {
        int yield = 0;
        foreach (ResourceDeposit deposit in tile.GetResourceDeposits())
        {
            Resource.Type type = deposit.GetDepositType();
            if (type == Resource.Type.Animals || type == Resource.Type.Grains || type == Resource.Type.Vegetables || type == Resource.Type.Fruit)
            {
                yield += deposit.GetDepositSize();
            }
        }
        return yield;
    }

    //Iterates through the resource deposits in the tile and returns the number of building resources (wood and stone).
    int YieldOfBuildingResource(Tile tile)
    {
        int yield = 0;
        foreach (ResourceDeposit deposit in tile.GetResourceDeposits())
        {
            Resource.Type type = deposit.GetDepositType();
            if (type == Resource.Type.Wood || type == Resource.Type.Stone)
            {
                yield += deposit.GetDepositSize();
            }
        }
        return yield;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Checks the happiness of the citizen by weighing all values that influence happiness.
    void HappinessCheck()
    {
    }

    //Returns the mental state of the citizen
    void MentalHealthCheck()
    {
        MentalState currentState;
        if (happiness < 15)                 //Dreaful if less than 15.
        {
            currentState = MentalState.Dreadful;
        }
        else if (happiness < 35)            //Unhappy if less than 35 but more then 14.
        {
            currentState = MentalState.Unhappy;
        }
        else if (happiness < 65)            //Content if less than 65 but more than 34.
        {
            currentState = MentalState.Content;
        }
        else if (happiness < 85)            //Happy if less than 85 but more than 64.
        {
            currentState = MentalState.Happy;
        }
        else                                //Ecstatic if above 84.
        {
            currentState = MentalState.Ecstatic;
        }
        mentalHealth = currentState;
    }
}
