using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class City : MonoBehaviour
{
    Settlement cityCenter;
    List<Settlement> districts;
    
    //Average of traits in the city. "City values"
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

    // Use this for initialization
    void Start () {
	
	}
	
	void FixedUpdate () {
	
	}

    void UpdateCity()
    {

    }


}
