using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InventoryManager inventoryManager;
    public static GameManager Instance; 
    public List<Item> items = new List<Item>();
    public GameObject obstacle;
    public Vector3 playerPosition;
    public List<Vector3> passedGrids;
    public List<Vector3> enemyGrids;
    public Vector3 gridNow;
    public GameObject[] enemiesToBeSpawned;
    public Vector3[] enemiesToBeSpawnedLocs;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        inventoryManager=GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        
    }
    private void Update() {
        if(GameObject.Find("PlayerMaze")!=null){
            playerPosition=GameObject.Find("PlayerMaze").transform.position;
        }
    }
    public void setPlayerPosition(Vector3 vector3){
        playerPosition=vector3;
    }
    

    void destroySmokesOnSceneChange(){
        for (int i = 0; i < passedGrids.Count; i++)
        {
            
        }
    }
    
    public void destroyObstacles(){
        obstacle.GetComponent<Obstacle>().destroyObstacle();
        GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().isCanMoveUp=GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().tileNow.isCanMoveUpObs;
        GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().iscanMoveRight=GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().tileNow.iscanMoveRightObs;
        GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().isCanMoveLeft=GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().tileNow.isCanMoveLeftObs;
        GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().isCanMoveDown=GameObject.Find("PlayerMaze").GetComponent<PlayerMovement>().tileNow.isCanMoveDownObs;
    }

}
