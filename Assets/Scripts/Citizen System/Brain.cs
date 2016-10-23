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

    private MentalState mentalHealth;   //The current mental state of the citizen.
    public enum MentalState             //Mental health affects the ability of the citizen to perform tasks.
    {
        Ecstatic,   //85-99. Provides 25% boost to production.
        Happy,      //65-84.
        Content,    //35-64.
        Unhappy,    //15-34.
        Dreadful    //0 -14.
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
        //Check the happiness of the citizen.

        //Set the mental health state
        mentalHealth = MentalHealthCheck(body.GetHappiness());

        //Decide to move/leave settlement
    }

    //Returns the mental state of the citizen
    MentalState MentalHealthCheck(int happiness)
    {
        if (happiness < 15)                 //Dreaful if less than 15.
        {
            return MentalState.Dreadful;
        }
        else if (happiness < 35)            //Unhappy if less than 35 but more then 14.
        {
            return MentalState.Unhappy;
        }
        else if (happiness < 65)            //Content if less than 65 but more than 34.
        {
            return MentalState.Content;
        }
        else if (happiness < 85)            //Happy if less than 85 but more than 64.
        {
            return MentalState.Happy;
        }
        else                                //Ecstatic if above 84.
        {
            return MentalState.Ecstatic;
        }
    }
}
