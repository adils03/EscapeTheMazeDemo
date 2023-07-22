using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameObject obstacle;
    public Vector3 playerPosition;
    public List<Vector3> passedGrids;
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
    }

}
