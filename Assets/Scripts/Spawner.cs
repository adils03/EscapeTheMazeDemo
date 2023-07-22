using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameManager gameManager;
    
    private void Awake() {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start() {
        spawnEnemies();
    }
    void spawnEnemies(){
        for (int i = 0; i <gameManager.enemiesToBeSpawned.Length; i++)
        {
            Instantiate(gameManager.enemiesToBeSpawned[i],gameManager.enemiesToBeSpawnedLocs[i],Quaternion.identity);
        }
    }

}
