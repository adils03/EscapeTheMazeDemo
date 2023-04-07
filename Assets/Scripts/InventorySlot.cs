using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(transform.childCount==0){
            DraggableItem inventoryItem = eventData.pointerDrag.GetComponent<DraggableItem>();
            if(inventoryItem!=null){
                inventoryItem.parentAfterDrag=transform;
            }
        }
        
    }
}
