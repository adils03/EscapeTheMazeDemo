using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed=5f;
    private Vector3 origPos,targetPos;
    private bool isMoving;
    [HideInInspector]public bool isCanMoveUp=false;
    [HideInInspector]public bool iscanMoveRight=false;
    [HideInInspector]public bool isCanMoveLeft=false;
    [HideInInspector]public bool isCanMoveDown=false;
    private float timeToMove=0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            isCanMoveUp = tile.isCanMoveUp;
            iscanMoveRight = tile.iscanMoveRight;
            isCanMoveLeft = tile.isCanMoveLeft;
            isCanMoveDown = tile.isCanMoveDown;
        }
        
    }
}
