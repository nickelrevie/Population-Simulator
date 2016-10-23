using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneticCode
{
    //Enum of all the genetic traits
    //These affect the behavior of the Citizen. Go from 0-99 in the actual array. Some are not applicable until more AI systems are implemented.
    public enum GeneticTrait
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
    private int numberOfTraits = 10;    //Number of traits in the genetic trait enum
    private int[] geneticTraits;        //Genetic trait array

    //Constructor for when new citizens are born.
    public GeneticCode(GeneticCode parentCode)
    {
        geneticTraits = parentCode.geneticTraits;
        RerollRandomTraits();
    }

    //Constructor for genetic code made when citizens are generated at the start of a simulation.
    public GeneticCode()
    {
        geneticTraits = new int[numberOfTraits];
        RollStartingTraits();
    }

    //Returns the trait value of the genetic trait.
    public int GetTrait(GeneticTrait trait)
    {
        return geneticTraits[(int)trait];
    }
    //Overloaded method for integer inputs.
    public int GetTrait(int trait)
    {
        return geneticTraits[trait];
    }
    
    //Rerolls a random number (1-3) of traits.
    void RerollRandomTraits()
    {
        int traitsToChange = Random.Range(1, 4);            //The number of traits to change is 1-3
        List<int> traitsChanged = new List<int>();          //Creates empty list to keep track of traits that were change and their values.
        for (int i = 0; i < traitsToChange; i++)
        {
            int trait = Random.Range(0, numberOfTraits);    //Chooses a trait to change
            while (traitsChanged.Contains(trait))           //If the trait is already in the changed array, keep rerolling the trait to modify until it is no longer in the list.
            {
                trait = Random.Range(0, numberOfTraits);
            }
            traitsChanged.Add(trait);                       //Adds it to the list of changed traits
            RollTrait(trait);                               //Rolls a new value for the trait.
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

    //Method that actually rolls the trait. Used in both types of code generation.
    void RollTrait(int trait)
    {
        geneticTraits[trait] = Random.Range(0, 100);  //Rolls a random number for this specific trait.
    }
}
