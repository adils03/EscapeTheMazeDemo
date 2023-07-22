using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
public GameObject button;
public Sprite buttonSprite;
public GameObject obstacle;
public Item item;
public bool HasObstacle=false;
public bool isCanMoveUp;
public bool iscanMoveRight;
public bool isCanMoveLeft;
public bool isCanMoveDown;
public bool isCanMoveUpObs;
public bool iscanMoveRightObs;
public bool isCanMoveLeftObs;
public bool isCanMoveDownObs;
private void Awake() {
    buttonSprite=obstacle.GetComponent<Obstacle>().sprite;
    button=obstacle.GetComponent<Obstacle>().button;
    item=obstacle.GetComponent<Obstacle>().item;
}
public void fixMoves(){
HasObstacle=false;
isCanMoveUp=isCanMoveUpObs;
iscanMoveRight=iscanMoveRightObs;
isCanMoveLeft=isCanMoveLeftObs;
isCanMoveDown=isCanMoveDownObs;
}
}
