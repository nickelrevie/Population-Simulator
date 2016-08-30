using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    private TileManager manager;

    public GameObject selectedOverlay;
    public GameObject hoverOverlay;
    private bool isSelected = false;

    private int[] location = new int[2]; //x,y

    private bool isOccupied;

    private Geography geography;
    private List<ResourceDeposit> resourceDeposits;
    private Sprite sprite;

    private List<Citizen> inhabitants;
    private Settlement settlement;
    private bool hasSettlement = false;

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

    public void ApplyGeography(Geography _geography)
    {
        geography = _geography;
        resourceDeposits = geography.GetResourceDeposits();
        sprite = geography.GetSprite();
        SetSprite();
    }

    private void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void AddInhabitant(Citizen inhabitant)
    {
        inhabitants.Add(inhabitant);
        if (hasSettlement)
        {
            settlement.AddInhabitant(inhabitant);
        }
    }

    public bool GetHasSsettlement()
    {
        return hasSettlement;
    }

    public Settlement GetSettlement()
    {
        return settlement;
    }
    
    public void AddNewSettlement()
    {
        settlement = gameObject.AddComponent<Settlement>();
    }
}