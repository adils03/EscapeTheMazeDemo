using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Item tripleBullet;
    [SerializeField] Item exBullet;
    [Header("Speed")]
    [SerializeField] float speed=5f;
    [SerializeField] float speedMultiplier=2f;
    [Header("Projectile")]
    [SerializeField] float shootDelay;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject bigProjectile;
    [SerializeField] GameObject smallProjectile;
    [SerializeField] Vector3 projectileOffsetRight;
    [SerializeField] Vector3 projectileOffsetLeft;
    [SerializeField] Vector3 projectileOffsetUp;
    [SerializeField] Vector3 projectileOffsetDown;
    [SerializeField]private float damageRate;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 look;
    private float horizontalInput;
    private float verticalInput;
    private bool canFire=true;
    private bool canMove=true;
    private bool canTakedamage=true;
    [Header("Bounds")]
    [SerializeField]private float boundX;
    [SerializeField]private float boundY;
    private Vector2 moveDirection;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void Start()
    {
        
    }

    void Update() {
       if(canMove){
        processUnits();
       } 
       shot();
       if(Input.GetMouseButton(2)){
        SceneController.LoadScene(1);
       }
       keepBounds();
    }
    void FixedUpdate()
    {
        movement();
    }
    void processUnits(){
       horizontalInput = Input.GetAxisRaw("Horizontal");
       verticalInput = Input.GetAxisRaw("Vertical");
       animator.SetFloat("speed",moveDirection.SqrMagnitude());
       look= transform.position-Camera.main.ScreenToWorldPoint(Input.mousePosition);
       moveDirection = new Vector2(horizontalInput,verticalInput).normalized;
       animator.SetFloat("horizontal",horizontalInput);
       animator.SetFloat("vertical",verticalInput);
        
    }
    void movement(){
            if(Input.GetKey(KeyCode.Space)){
                rb.velocity = new Vector2(moveDirection.x*speed*speedMultiplier*Time.deltaTime,moveDirection.y*speed*speedMultiplier*Time.fixedDeltaTime);
                animator.speed=1f;
            }else{
                rb.velocity = new Vector2(moveDirection.x*speed*Time.deltaTime,moveDirection.y*speed*Time.fixedDeltaTime);
                animator.speed=0.5f;
            }
            if(canMove==false){
                rb.constraints=RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;
            }
            else{
                rb.constraints=RigidbodyConstraints2D.None;
                rb.constraints=RigidbodyConstraints2D.FreezeRotation;
            }
    }
    void shot(){
        if(gameManager.items.Contains(exBullet)){
            projectile=bigProjectile;
        }else{projectile=smallProjectile;}
        if(Input.GetKey(KeyCode.RightArrow)&&canFire){
        canFire=false;
        animator.SetBool("isShooting",true);
        StartCoroutine(shotDelay(0));
       }
       else if(Input.GetKey(KeyCode.LeftArrow)&&canFire){
        canFire=false;
        animator.SetBool("isShooting",true);
        StartCoroutine(shotDelay(1));
       }
       else if(Input.GetKey(KeyCode.UpArrow)&&canFire){
        canFire=false;
        animator.SetBool("isShooting",true);
        StartCoroutine(shotDelay(2));
       }
       else if(Input.GetKey(KeyCode.DownArrow)&&canFire){
        canFire=false;
        animator.SetBool("isShooting",true);
        StartCoroutine(shotDelay(3));
       }
    }

    IEnumerator shotDelay(int number){
        canMove=false;
        if(number==0){
            Instantiate(projectile,transform.position+projectileOffsetRight,Quaternion.Euler(new (0, 0, 0)));
            if(gameManager.items.Contains(tripleBullet)){
                Instantiate(projectile,transform.position+projectileOffsetRight+new Vector3(-0.1f,-0.2f,0),Quaternion.Euler(new (0, 0, 0)));
                Instantiate(projectile,transform.position+projectileOffsetRight+new Vector3(-0.2f,0.2f,0),Quaternion.Euler(new (0, 0, 0)));
            }
            animator.Play("pompaliRight");
        }
        else if(number==1){
            Instantiate(projectile,transform.position+projectileOffsetLeft,Quaternion.Euler(new (0, 0, 180)));
            if(gameManager.items.Contains(tripleBullet)){
                Instantiate(projectile,transform.position+projectileOffsetLeft+new Vector3(0.1f,-0.2f,0),Quaternion.Euler(new (0, 0, 180)));
                Instantiate(projectile,transform.position+projectileOffsetLeft+new Vector3(0.2f,0.2f,0),Quaternion.Euler(new (0, 0, 180)));
            }
            animator.Play("pompaliLeft");
        }
        else if(number==2){
            Instantiate(projectile,transform.position+projectileOffsetUp,Quaternion.Euler(new (0, 0, 90)));
            if(gameManager.items.Contains(tripleBullet)){
                Instantiate(projectile,transform.position+projectileOffsetUp+new Vector3(0.2f,-0.1f,0),Quaternion.Euler(new (0, 0, 90)));
                Instantiate(projectile,transform.position+projectileOffsetUp+new Vector3(-0.2f,-0.2f,0),Quaternion.Euler(new (0, 0, 90)));
            }
            animator.Play("pompaliUp");

        }
        else if(number==3){
            Instantiate(projectile,transform.position+projectileOffsetDown,Quaternion.Euler(new (0, 0, 270)));
            if(gameManager.items.Contains(tripleBullet)){
                Instantiate(projectile,transform.position+projectileOffsetDown+new Vector3(-0.2f,0.1f,0),Quaternion.Euler(new (0, 0, 270)));
                Instantiate(projectile,transform.position+projectileOffsetDown+new Vector3(0.2f,0.2f,0),Quaternion.Euler(new (0, 0, 270)));
            }
            animator.Play("pompaliDown");
        }
        animator.SetBool("isShooting",false);
        yield return new WaitForSeconds(shootDelay);
        canFire=true;
        canMove=true;
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy"&&canTakedamage){
        GetComponent<Health>().takeDamage(other.GetComponent<Enemy>().damage); 
        }
    }

    void keepBounds(){
        if(transform.position.x>=boundX){
            transform.position=new Vector2(boundX,transform.position.y);
        }
        if(transform.position.x<=-boundX){
            transform.position=new Vector2(-boundX,transform.position.y);
        }
        if(transform.position.y>=boundY){
            transform.position=new Vector2(transform.position.x,boundY);
        }
        if(transform.position.y<=-boundY){
            transform.position=new Vector2(transform.position.x,-boundY);
        }
 
    }
   /* IEnumerator shotDelay(){
        canMove=false;
        yield return new WaitForSeconds(shootDelay);
        if(moveDirection.x==1||moveDirection.x==0&&moveDirection.y==0||moveDirection.x>0&&moveDirection.y>0||moveDirection.x>0&&moveDirection.y<0){
            Instantiate(projectile,transform.position+projectileOffsetRight,Quaternion.Euler(new (0, 0, 0)));
        }
        else if(moveDirection.x==-1||moveDirection.x<0&&moveDirection.y>0||moveDirection.x<0&&moveDirection.y<0){
            Instantiate(projectile,transform.position+projectileOffsetLeft,Quaternion.Euler(new (0, 0, 180)));
        }
        else if(moveDirection.y==1){
            Instantiate(projectile,transform.position+projectileOffsetUp,Quaternion.Euler(new (0, 0, 90)));
        }
        else if(moveDirection.y==-1){
            Instantiate(projectile,transform.position+projectileOffsetDown,Quaternion.Euler(new (0, 0, 270)));
        }
        animator.SetBool("isShooting",false);
        canFire=true;
        canMove=true;
        
    }*/
}
