using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float shootDelay;
    [SerializeField] GameObject projectile;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRendererLeg;
    private SpriteRenderer spriteRendererBody;
    private Animator bacakAnim;
    private Animator gövdeAnim;
    public GameObject gövde;
    public GameObject bacak;
    private float horizontalInput;
    private float verticalInput;
    private bool canFire=true;
    private bool canTakedamage=true;
    [SerializeField]private float damageRate;
    private float xRange=5.25f;
    private float yRange=2.05f;

    private Vector2 moveDirection;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        bacakAnim=bacak.gameObject.GetComponent<Animator>();
        gövdeAnim=gövde.gameObject.GetComponent<Animator>();
        spriteRendererBody=transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        spriteRendererLeg=transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    void Update() {
       processUnits();
       shot();
    }
    void FixedUpdate()
    {
        keepBounds();
        movement();
    }
    void processUnits(){
       horizontalInput = Input.GetAxisRaw("Horizontal");
       verticalInput = Input.GetAxisRaw("Vertical");
       float look = transform.position.x-Camera.main.ScreenToWorldPoint(Input.mousePosition).x; 
       if(look>0&&canFire){
       spriteRendererBody.flipX=true;
       spriteRendererLeg.flipX=true;
       }
       if(look<0&&canFire){
       spriteRendererBody.flipX=false;
       spriteRendererLeg.flipX=false;
       }
       moveDirection = new Vector2(horizontalInput,verticalInput).normalized;

    }
    void movement(){
        rb.velocity = new Vector2(moveDirection.x*speed*Time.deltaTime,moveDirection.y*speed*Time.deltaTime);
        if(horizontalInput!=0||verticalInput!=0){
            bacakAnim.SetBool("isWalking",true);
            gövdeAnim.SetBool("isWalking",true);
        }
        else{
            bacakAnim.SetBool("isWalking",false);
            gövdeAnim.SetBool("isWalking",false);
        }
    }
    void keepBounds(){
        if(transform.position.x<-xRange){
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        if(transform.position.x>xRange){
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }
        if(transform.position.y<-yRange){
            transform.position = new Vector3(transform.position.x,-yRange,transform.position.z);
        }
        if(transform.position.y>yRange){
            transform.position = new Vector3(transform.position.x,yRange,transform.position.z);
        }
    }
    void shot(){
        
        if(Input.GetMouseButtonDown(0)&&canFire){
        
        canFire=false;
        gövdeAnim.Play("tüfekVuruş");
        StartCoroutine(shotDelay());
       }
    }

    IEnumerator shotDelay(){
        yield return new WaitForSeconds(shootDelay);
        if(spriteRendererBody.flipX==true){
            Instantiate(projectile,transform.position+new Vector3(0.3f,0.05f,0),new Quaternion(0,0,270,0));
        }
        if(spriteRendererBody.flipX==false){
            Instantiate(projectile,transform.position+new Vector3(0.3f,0.05f,0),Quaternion.identity);
        }
        canFire=true;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy"&&canTakedamage){
        GetComponent<Health>().takeDamage(other.GetComponent<Enemy>().damage); 
        StartCoroutine(damageDelay());
        }
    }
    
    

    IEnumerator damageDelay(){
        canTakedamage=false;
        spriteRendererBody.color=new Color32(255,192,192,255);
        spriteRendererLeg.color=new Color32(255,192,192,255);
        yield return new WaitForSeconds(damageRate);
        spriteRendererBody.color=new Color32(255,255,255,255);
        spriteRendererLeg.color=new Color32(255,255,255,255);
        canTakedamage=true;
    }
}
