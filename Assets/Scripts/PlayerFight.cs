using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float shootDelay;
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
    private Vector3 forcedirection;
    private float xRange=5.25f;
    private float yRange=2.05f;

    private Vector2 moveDirection;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        bacakAnim=bacak.gameObject.GetComponent<Animator>();
        gövdeAnim=gövde.gameObject.GetComponent<Animator>();
        spriteRendererBody=transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        spriteRendererLeg=transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
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

       if(horizontalInput<0&&canFire){
       spriteRendererBody.flipX=true;
       spriteRendererLeg.flipX=true;
       }
       if(horizontalInput>0&&canFire){
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
        canFire=true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag=="Enemy"){
        forcedirection = transform.position-other.transform.position;
        forcedirection.Normalize(); 
        Debug.Log("player");
        transform.Translate(forcedirection/3,Space.Self);
        }
    }
    
}
