using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CitizenManager : MonoBehaviour {
    private List<Citizen> populationList;
    private int totalNumberOfCitizens;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //Goes through the list and updates citizens. They perform all actions not related to settlement work.
    void UpdateAllCitizens()
    {
        foreach (Citizen person in populationList)
        {
            person.UpdateCitizen();
        }
    }
}
