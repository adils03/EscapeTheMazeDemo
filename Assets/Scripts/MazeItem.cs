using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeItem : MonoBehaviour
{
  [SerializeField]private Item item;
  [SerializeField]InventoryManager InventoryManager;
    
  private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        InventoryManager.AddItem(item);
        Destroy(gameObject);
    }
  }
}
