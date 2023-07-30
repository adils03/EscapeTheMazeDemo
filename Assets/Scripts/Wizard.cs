using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
[SerializeField] GameObject player;
[SerializeField] float speed;
[SerializeField] float moveCooldown;
[SerializeField] GameObject[] points;
[SerializeField] GameObject fireball;
[SerializeField] GameObject fireballPos;
[SerializeField] GameObject fireBallPosFlip;
[SerializeField] float throwFireBallCd;
[SerializeField] float fireBallCooldown;
[SerializeField] float forceAmount;
[SerializeField] float shockWaveCd;
[SerializeField] float shockWaveCooldown;
[SerializeField] float shockWaveDamage;
float lastFireball;
float lastShockWave;
private GameObject fireBallPosLoc;
Animator animator;
private bool canMove=true;
private bool canThrowFireBall=true;
private bool canShockWave=true;
int point;
float lastMove;
Vector3 moveDirection = new Vector3();
SpriteRenderer spriteRenderer;
Rigidbody2D rb2d;
[SerializeField] bool applyCameraShake;
ShakeCamera cameraShake;
private void Awake() {
    cameraShake=Camera.main.GetComponent<ShakeCamera>();
    rb2d=GetComponent<Rigidbody2D>();
    spriteRenderer=GetComponent<SpriteRenderer>();
    animator=GetComponent<Animator>();
}
private void FixedUpdate() {
    move();
}
private void Update() {
    moveDirectionFind();
    fireBallWitchCd();
    shockWaveWithCd();
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
void fireBallWitchCd(){
if(Time.time-lastFireball<fireBallCooldown){
    return;
}
lastFireball=Time.time;
if(canThrowFireBall){
        StartCoroutine(throwFireBall());
    }
}
IEnumerator throwFireBall(){
canMove=false;
canShockWave=false;
Instantiate(fireball,fireBallPosLoc.transform.position,Quaternion.identity);
canThrowFireBall=false;
animator.SetTrigger("fireball");
yield return new WaitForSeconds(throwFireBallCd);
canMove=true;
canShockWave=true;
canThrowFireBall=true;
animator.SetBool("isWalking",true);
}
void shockWaveWithCd(){
if(Time.time-lastShockWave<shockWaveCooldown){
    return;
}
lastShockWave=Time.time;
if(canShockWave&&Vector3.Distance(player.transform.position,transform.position)<1.5f){
    StartCoroutine(shockWave());
}
}
IEnumerator shockWave(){
    canThrowFireBall=false;
    canMove=false;
    player.GetComponent<PlayerFight>().canMove=false;
    canShockWave=false;
    animator.SetTrigger("shockWave");
    yield return new WaitForSeconds(shockWaveCd);
    ShakeCamera_();
    player.transform.Translate((player.transform.position-transform.position)*Time.deltaTime*forceAmount);
    player.GetComponent<Health>().takeDamage(shockWaveDamage);
    canMove=true;
    canShockWave=true;
    animator.SetBool("isWalking",true);
    canThrowFireBall=true;
    player.GetComponent<PlayerFight>().canMove=true;
}
void ShakeCamera_(){
    if(cameraShake!=null&&applyCameraShake){
        cameraShake.Play();
    }
}
}
