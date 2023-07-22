using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
[SerializeField]private Tile[] tiles;
public GameObject button;
public Item item;
public Sprite sprite;
public void destroyObstacle(){
    for (int i = 0; i < tiles.Length; i++)
    {
        tiles[i].fixMoves();
        Destroy(gameObject);
    }
    tiles[0].button.SetActive(false);
}
}
