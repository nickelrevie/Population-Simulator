using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{ 

    public GameObject selectedOverlay;
    public GameObject hoverOverlay;
    private bool isSelected = false;

    private int[] location = new int[2]; //x,y

    private bool isOccupied;

    private Geography geography;
    private List<Resource> resourceList;
    private Sprite sprite;

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

    public void applyGeography(Geography _geography)
    {
        geography = _geography;
        resourceList = geography.getResourceList();
        sprite = geography.getSprite();
        setSprite();
    }

    private void setSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    bool getIsOccupied()
    {
        return isOccupied;
    }
}