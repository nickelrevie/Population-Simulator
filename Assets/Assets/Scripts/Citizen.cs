using UnityEngine;
using System.Collections;

public class Citizen : MonoBehaviour {

    private int age = 0;
    private int[] location; //x,y

    private int happiness = 0; //Happy and wealthy citizens are less likely to leave or rebel or attack people of differing values.
    private int wealth = 0; 
    private int productivity = 0;
    private int food = 0; //Hungry citizens are more likely to rebel or leave the area. 
    private int actions = 1; //reduces by one each time an action is done. Building a house, workshop etc

    private Citizen[] enemies;
    private Citizen[] allies;

    //Static Traits 0-99 in value;
    private int faith = 0; //Faith provides a happiness benefit when there are more of a similar faith value nearby.
    private int honor = 0; //Honor determines whether they will attempt to attack enemies.
    private int determination = 0; //Resists happiness decline when resources are scarce.
    private int loyalty = 0; //Determines whether a citizen is more likely to rebel or not rebel against their own allies.
    private int tolerance = 0; //A higher value raises happiness when there are differing values and lower values lower happiness when there are differing values. Also affects when Citizens get placed as an ally or enemy.
    private int creativity = 0; //A higher value increases productivity. Higher values also have a higher chance of moving to new areas.
    private int compassion = 0; //A higher value increases food and wealth distribution
    private int resourcefulness = 0; //Increases wealth when low on food. Increases food when low on wealth. Higher values raise the limits at which this occurs and the effectiveness.
    private int virtue = 0; //Higher virtue are less likely to be hostile to foreign values.
    private int wisdom = 0; //Higher wisdom increases the productivity of all allied Citizens.

    private Resource resourceWorked;
    private int resourceSkill;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void reproduce()
    {
        Citizen newCitizen = new Citizen();
    }
}
