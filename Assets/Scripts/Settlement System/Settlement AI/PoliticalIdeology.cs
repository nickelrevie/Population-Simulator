using UnityEngine;
using System.Collections;

public class PoliticalIdeology
{
    private Government government;

    public enum PoliticalTraits
    {
        Faith,              //Faith provides a happiness benefit when there are more of a similar faith value nearby.
        Honor,              //Honor increases happiness when the citizen has high health and is not starving
        Determination,      //Resists happiness decline when resources are scarce. Influences resource skill.
        Loyalty,            //Determines whether a citizen is likely to stay in the same settlement even if on low happiness
        Tolerance,          //A higher value raises happiness when there are differing values and lower values lower happiness when there are differing values.
        Creativity,         //Increases the rate of resource skill development. Higher values also make the citizen lose happiness when staying in one spot for a long time.
        Compassion,         //A higher value increases food production in a settlement and adds a happiness bonus in a city.
        Resourcefulness,    //Stays healthier on low health values. Uses less food and resists happiness decline when on low food. Higher values increase the effectiveness.
        Virtue,             //Higher virtue artificially boosts compassion, wisdom, loyalty and tolerance when calculating their effects.
        Wisdom              //Higher wisdom increases the resource skill of citizens mining the same resource deposit.
    }

    private readonly int numberOfTraits = 10;       //Number of traits in the political trait enum
    private int[] politicalTraits;                  //Political trait array

    public PoliticalIdeology(Government _government)
    {
        government = _government;
    }
}
