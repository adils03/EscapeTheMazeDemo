using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float shootDelay;
    [SerializeField] GameObject projectile;
    [SerializeField] Vector3 projectileOffsetRight;
    [SerializeField] Vector3 projectileOffsetLeft;
    [SerializeField] Vector3 projectileOffsetUp;
    [SerializeField] Vector3 projectileOffsetDown;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 look;
    private float horizontalInput;
    private float verticalInput;
    private bool canFire=true;
    private bool canMove=true;
    private bool canTakedamage=true;
    [SerializeField]private float damageRate;

    private Vector2 moveDirection;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
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
            rb.velocity = new Vector2(moveDirection.x*speed*Time.deltaTime,moveDirection.y*speed*Time.fixedDeltaTime);
            if(canMove==false){
                rb.constraints=RigidbodyConstraints2D.FreezePosition|RigidbodyConstraints2D.FreezeRotation;
            }
            else{
                rb.constraints=RigidbodyConstraints2D.None;
                rb.constraints=RigidbodyConstraints2D.FreezeRotation;
            }
    }
    void shot(){
        if(Input.GetMouseButtonDown(0)&&canFire){
        canFire=false;
        animator.SetBool("isShooting",true);
        StartCoroutine(shotDelay());
       }
    }

    IEnumerator shotDelay(){
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
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy"&&canTakedamage){
        GetComponent<Health>().takeDamage(other.GetComponent<Enemy>().damage); 
        }
    }
}
