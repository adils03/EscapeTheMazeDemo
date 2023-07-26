using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed=5f;
    private Vector3 origPos,targetPos;
    private bool isMoving;
    GameObject smoke;
    [HideInInspector]public bool isCanMoveUp=false;
    [HideInInspector]public bool iscanMoveRight=false;
    [HideInInspector]public bool isCanMoveLeft=false;
    [HideInInspector]public bool isCanMoveDown=false;
    public Tile tileNow;
    private float timeToMove=0.2f;
    private GameManager gameManager;
    private InventoryManager inventoryManager;
    
    private void Awake() {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        inventoryManager=GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        
    }
    void Start()
    {
        transform.position=gameManager.playerPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.E)){
            SceneController.LoadScene(2);
        }
       movement();
    }


    void movement(){
         if(Input.GetKey((KeyCode.W))&&!isMoving&&isCanMoveUp){
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if(Input.GetKey((KeyCode.A))&&!isMoving&&isCanMoveLeft){
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if(Input.GetKey((KeyCode.D))&&!isMoving&&iscanMoveRight){
            StartCoroutine(MovePlayer(Vector3.right));
        }
        if(Input.GetKey((KeyCode.S))&&!isMoving&&isCanMoveDown){
            StartCoroutine(MovePlayer(Vector3.down));
        }
    }

    IEnumerator MovePlayer(Vector3 direction){
        
        isMoving=true;

        float elapsedTime=0;

        origPos= transform.position;
        targetPos=origPos + direction;

        while(elapsedTime<timeToMove){
            transform.position = Vector3.Lerp(origPos,targetPos,(elapsedTime/timeToMove));
            elapsedTime+=Time.deltaTime;
            yield return null;
        }

        transform.position=targetPos;
        yield return new WaitForSeconds(0.4f);
        isMoving=false;
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Tile")){
            Tile tile = other.gameObject.GetComponent<Tile>();
            tileNow=tile;
            isCanMoveUp = tile.isCanMoveUp;
            iscanMoveRight = tile.iscanMoveRight;
            isCanMoveLeft = tile.isCanMoveLeft;
            isCanMoveDown = tile.isCanMoveDown;
            if(tile.HasObstacle&&inventoryManager.CheckItemInSlots(tile.item)){
                tile.button.GetComponent<Image>().sprite=tile.buttonSprite;
                tile.button.SetActive(true);
                gameManager.obstacle=tile.obstacle;
            }
            if(tile.HasObstacle==false){
                if(tile.button!=null){
                    tile.button.SetActive(false);
                }
            }
        }
        if(other.CompareTag("Smoke")){
            smoke = other.gameObject;
            smoke.GetComponentInParent<Grid>().destroySmoke();
        }
        
    }

}
