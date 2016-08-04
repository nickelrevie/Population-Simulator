using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{ 

    public GameObject selectedOverlay;
    public GameObject hoverOverlay;
    private bool isSelected = false;

    private int[] location = new int[2]; //x,y

    private bool isOccupied;

    //Resource variables
    private int foodSupplyTotal;
    private int foodSupplyNet;
    private int foodConsumed;
    private ArrayList resourcesOnTile;
    private ArrayList resourcesProduced;

    //City variables
    private int population;
    private int space;
    private ArrayList buildingList;

    private District.type districtType;
    //Geography variables

    private Geography geographyType;

    void Start()
    {
        selectedOverlay.SetActive(false);
    }

    void FixedUpdate()
    {

    }

    void OnMouseEnter()
    {
        hoverOverlay.SetActive(true);
    }

    void OnMouseExit()
    {
        hoverOverlay.SetActive(false);
    }

    void OnMouseDown()
    {
        //Select the tile
        selectedOverlay.SetActive(!isSelected);
        isSelected = !isSelected;
    }

    ///////////////////////////////////////////////////////////

    void updateTile()
    {

    }

    void applyGeography()
    {

    }

    bool getIsOccupied()
    {
        return isOccupied;
    }
}