using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public InventorySlot[] InventorySlots;
    public GameObject inventoryItemPrefab;
    public Item item1;
    public int maxStackedItems=4;
    private void Awake() {
        if (instance != null)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject);
    }
    //Add item to empty slot
    public bool AddItem(Item item){
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            DraggableItem itemInSLot = slot.GetComponentInChildren<DraggableItem>();
            if(itemInSLot!=null&&itemInSLot.item==item&&itemInSLot.count<maxStackedItems&&itemInSLot.item.stackable){
                itemInSLot.count++;
                itemInSLot.RefreshCount();
                if(ActionType.Attack==item.actionType){
                    return true;
                }
                return true;
                
            }
        }
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            DraggableItem itemInSLot = slot.GetComponentInChildren<DraggableItem>();
            if(itemInSLot==null){
                SpawnNewItem(item,slot);
                return true;
            }
        }
        return false;   
    }
    //Spawn item on given slot
    void SpawnNewItem(Item item,InventorySlot slot){
        GameObject newItemGo = Instantiate(inventoryItemPrefab,slot.transform);
        DraggableItem draggableItem = newItemGo.GetComponent<DraggableItem>();
        draggableItem.InitialiseItem(item);
    }
    public bool CheckItemInSlots(Item item)
{
    for (int i = 0; i < InventorySlots.Length; i++)
    {
        InventorySlot slot = InventorySlots[i];
        DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
        if (itemInSlot != null && itemInSlot.item == item)
        {
            return true;
        }
    }
    return false;
    }


}
