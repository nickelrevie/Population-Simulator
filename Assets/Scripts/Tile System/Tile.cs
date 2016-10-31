using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    //Each tile can communicate with the tile manager.
    private TileMap tileMap;

    //The overlays so that the user knows when they have selected the tile or are hovering over it.
    //The is selected variable for the selected
    public GameObject selectedOverlay;
    public GameObject hoverOverlay;
    private bool isSelected = false;

    //Location of the tile in the TileMap
    private int[] location = new int[2]; //x,y

    //The geography of the sprite, the resource deposits on the tile due to the geography, and the sprite image of the geography type.
    private Geography geography;
    private List<ResourceDeposit> resourceDeposits;
    private Sprite sprite;

    //The list of inhabitants, the settlement on top of it, and whether the tile has a settlement on it.
    private List<Citizen> inhabitants;
    private Settlement settlement;
    private bool hasSettlement = false;

    //When the tile object is created make sure to set the selected overlay to off.
    void Start()
    {
        selectedOverlay.SetActive(false);
    }

    void FixedUpdate()
    {

    }

    //When the mouse hovers over, set the hover overlay on.
    void OnMouseEnter()
    {
        hoverOverlay.SetActive(true);
    }

    //When the mouse exist, set the hover overlay off.
    void OnMouseExit()
    {
        hoverOverlay.SetActive(false);
    }

    //If the mouse button is clicked over the tile, make sure the selected state it reversed.
    void OnMouseDown()
    {
        //Select the tile
        selectedOverlay.SetActive(!isSelected);
        isSelected = !isSelected;
    }

    ///////////////////////////////////////////////////////////
    //Will update the tile every timestep
    void updateTile()
    {

    }

    //Applies the geography stats to the tile. It adds the resource deposit list to the tile and the sprite. It also sets
    public void ApplyGeography(Geography _geography)
    {
        geography = _geography;
        resourceDeposits = geography.GetResourceDeposits();
        sprite = geography.GetSprite();
        SetSprite();
    }

    //Sets the image of the tile.
    private void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    //Adds a citizen to the inhabitant list of the tile, if there is a settlement on the tile, it will also add them to the inhabiant list of that.
    public void AddInhabitant(Citizen inhabitant)
    {
        inhabitants.Add(inhabitant);
        if (hasSettlement)
        {
            settlement.AddInhabitant(inhabitant);
        }
    }
    
    //Returns true if there is a settlement on the tile.
    public bool HasSettlement()
    {
        return hasSettlement;
    }

    //Returns true if there is at least one settler living on the tile.
    public bool HasSettlers()
    {
        return inhabitants.Count > 0;
    }

    //Returns the settlement object.
    public Settlement GetSettlement()
    {
        return settlement;
    }

    //Returns the tile manager object
    public TileMap GetTileMap()
    {
        return tileMap;
    }
    
    //Adds a settlement to the tile when one is created.
    public void AddNewSettlement()
    {
        settlement = gameObject.AddComponent<Settlement>();
    }

    public int[] GetLocation()
    {
        return location;
    }

    public List<ResourceDeposit> GetResourceDeposits()
    {
        return resourceDeposits;
    }
}