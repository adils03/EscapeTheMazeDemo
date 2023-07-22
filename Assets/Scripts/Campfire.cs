using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Campfire : MonoBehaviour , IDropHandler 
{
    public GameObject barManager;
    private GameObject droppingItem;
    
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        droppingItem = eventData.pointerDrag;
        DraggableItem itemDrop = droppingItem.GetComponent<DraggableItem>();
        
        if(itemDrop.itemType.ToString()=="FireFuel"){
            Destroy(droppingItem);
            Debug.Log("wood");
        }
    }
}
