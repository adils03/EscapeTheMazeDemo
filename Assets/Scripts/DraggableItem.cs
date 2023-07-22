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
    //Variables of item
    public string itemType;
    

    //Initialise new item
    public void InitialiseItem(Item newItem){
        item = newItem;
        image.sprite = newItem.image;
        itemType=newItem.itemType.ToString();
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
