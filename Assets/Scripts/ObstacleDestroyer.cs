using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
GameManager gameManager;
private void Awake() {
    gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
}
public void DestroyObstacle(){
    gameManager.destroyObstacles();
}
}
