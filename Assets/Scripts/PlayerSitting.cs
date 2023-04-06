using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSitting : MonoBehaviour , IDropHandler
{
    public GameObject barManager;
    private GameObject droppingItem;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        droppingItem = eventData.pointerDrag;
        DraggableItem itemDrop = droppingItem.GetComponent<DraggableItem>();
        //Eat food
        if(itemDrop.itemType.ToString()=="Food"){
            Destroy(droppingItem);
            barManager.GetComponent<BarManager>().addHunger(itemDrop.count*itemDrop.foodAmount);
        }
        if(itemDrop.itemType.ToString()=="Water"){
            Destroy(droppingItem);
            barManager.GetComponent<BarManager>().addWater(itemDrop.count*itemDrop.waterAmount);
        }
        if(itemDrop.itemType.ToString()=="Health"){
            Destroy(droppingItem);
            barManager.GetComponent<BarManager>().addHealth(itemDrop.count*itemDrop.healthAmount);
        }
        if(itemDrop.itemType.ToString()=="Sanity"){
            Destroy(droppingItem);
            barManager.GetComponent<BarManager>().addSanity(itemDrop.count*itemDrop.sanityAmount);
        }
        if(itemDrop.itemType.ToString()=="Sleep"){
            Destroy(droppingItem);
            barManager.GetComponent<BarManager>().addSleep(itemDrop.count*itemDrop.sleepAmount);
        }
    }
}
