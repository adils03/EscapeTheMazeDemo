using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
[SerializeField] GameObject player;
[SerializeField] float speed;
[SerializeField] float moveCooldown;
[SerializeField] GameObject[] points;
[SerializeField] float throwFireBallCd;
[SerializeField] GameObject fireball;
[SerializeField] GameObject fireballPos;
[SerializeField] GameObject fireBallPosFlip;
private GameObject fireBallPosLoc;
Animator animator;
private bool canMove=true;
private bool canThrowFireBall=true;
int point;
float lastMove;
Vector3 moveDirection = new Vector3();
SpriteRenderer spriteRenderer;
Rigidbody2D rb2d;
private void Awake() {
    rb2d=GetComponent<Rigidbody2D>();
    spriteRenderer=GetComponent<SpriteRenderer>();
    animator=GetComponent<Animator>();
}
private void FixedUpdate() {
    move();
}
private void Update() {
    moveDirectionFind();
    if(Input.GetKey(KeyCode.R)&&canThrowFireBall){
        canThrowFireBall=false;
        animator.SetBool("isWalking",false);
        StartCoroutine(throwFireBall());
    }
}

void moveDirectionFind(){
    moveDirection=points[point].transform.position-transform.position;
    moveDirection.Normalize();
    if(moveDirection.x<0){
        spriteRenderer.flipX=false;
        fireBallPosLoc=fireballPos;
    }else{spriteRenderer.flipX=true;fireBallPosLoc=fireBallPosFlip;}
}
void move(){
    if(!(Vector3.Distance(points[point].transform.position,transform.position)<1f)){
        rb2d.velocity=new Vector2(moveDirection.x*speed*Time.fixedDeltaTime,moveDirection.y*speed*Time.fixedDeltaTime);

    }else{point++;}
    point%=points.Length;
    if(canMove==false){
        rb2d.constraints=RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;
        }
        else{
            rb2d.constraints=RigidbodyConstraints2D.None;
            rb2d.constraints=RigidbodyConstraints2D.FreezeRotation;
        }
}

IEnumerator throwFireBall(){
canMove=false;
Instantiate(fireball,fireBallPosLoc.transform.position,Quaternion.identity);
animator.SetTrigger("fireball");
yield return new WaitForSeconds(throwFireBallCd);
canMove=true;
canThrowFireBall=true;
animator.SetBool("isWalking",true);
}


}
