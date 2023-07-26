using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeItem : MonoBehaviour
{
  [SerializeField]private Item item;
  InventoryManager InventoryManager;
  GameManager gameManager;
  
  private void Awake() {
    InventoryManager=GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    if(gameManager.items.Contains(item)){
      Destroy(gameObject);
    }
  }
  private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        gameManager.items.Add(item);
        InventoryManager.AddItem(item);
        Destroy(gameObject);
    }
  }
}
