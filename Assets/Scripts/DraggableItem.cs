using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour ,IBeginDragHandler ,IDragHandler,IEndDragHandler
{
    
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector]public Item item;
    [HideInInspector]public int count=1;
    [HideInInspector]public Transform parentAfterDrag;
    [HideInInspector]public bool consumable=false;
    //Variables of item
    [HideInInspector]public string itemType;
    [HideInInspector]public int foodAmount;
    [HideInInspector]public int waterAmount;
    [HideInInspector]public int healthAmount;
    [HideInInspector]public int sanityAmount;
    [HideInInspector]public int fireFuelAmount;
    [HideInInspector]public int sleepAmount;

    //Initialise new item
    public void InitialiseItem(Item newItem){
        item = newItem;
        image.sprite = newItem.image;
        consumable=newItem.consumable;
        itemType=newItem.itemType.ToString();
        foodAmount=newItem.foodAmount;
        waterAmount=newItem.waterAmount;
        healthAmount=newItem.healthAmount;
        sanityAmount=newItem.sanityAmount;
        fireFuelAmount=newItem.fireFuelAmount;
        sleepAmount=newItem.sleepAmount;
        Debug.Log(itemType);
        RefreshCount();
    }
    //Count Refresh
    public void RefreshCount(){
        countText.text= count.ToString();
        bool counTextActive = count > 1;
        countText.gameObject.SetActive(counTextActive);
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        countText.raycastTarget = false; 
        image.raycastTarget = false;  
        parentAfterDrag=transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position=Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        countText.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        
    }
}
