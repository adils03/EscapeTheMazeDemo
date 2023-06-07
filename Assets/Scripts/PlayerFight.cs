using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float shootDelay;
    private Rigidbody2D rb;
    private Animator bacakAnim;
    private Animator gövdeAnim;
    public GameObject gövde;
    public GameObject bacak;
    private float horizontalInput;
    private float verticalInput;
    private bool canFire=true;

    private Vector2 moveDirection;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        bacakAnim=bacak.gameObject.GetComponent<Animator>();
        gövdeAnim=gövde.gameObject.GetComponent<Animator>();
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
         movement();
    }
    void processUnits(){
       horizontalInput = Input.GetAxisRaw("Horizontal");
       verticalInput = Input.GetAxisRaw("Vertical");

       if(horizontalInput<0&&canFire){
        transform.rotation=new Quaternion(0,180,0,0);
       }
       if(horizontalInput>0&&canFire){
        transform.rotation=new Quaternion(0,0,0,0);
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
}
