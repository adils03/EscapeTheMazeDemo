using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameManager gameManager;
    public List<GameObject> enemies = new List<GameObject>();
    private GameObject canvas;
    private int enemyCount;
    
    private void Awake() {
        canvas=GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start() {
        canvas.SetActive(false);
        spawnEnemies();
        enemyCount=enemies.Count;
    }
    private void Update() {
        for (int i = enemies.Count - 1; i >= 0; i--)
{
        if (enemies[i] == null)
        {
        enemies.RemoveAt(i);
        }
        if(enemies.Count==0){
            SceneController.LoadScene(1);
            canvas.SetActive(true);
            gameManager.enemyGrids.Add(gameManager.gridNow);
        }
}
    }
    void spawnEnemies(){
        for (int i = 0; i <gameManager.enemiesToBeSpawned.Length; i++)
        {
            GameObject obj =Instantiate(gameManager.enemiesToBeSpawned[i],gameManager.enemiesToBeSpawnedLocs[i],Quaternion.identity);
            enemies.Add(obj);
        }
    }

}
