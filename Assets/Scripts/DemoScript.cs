using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
   public InventoryManager inventoryManager;
   public Item[] itemToPickup;

   public void PickupItem(int id ){
     bool result = inventoryManager.AddItem(itemToPickup[id]);
   }
}
