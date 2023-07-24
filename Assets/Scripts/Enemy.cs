using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed;
    [SerializeField] float waitTime;
    public float damage;
    private Vector3 lookDirection;
    private Rigidbody2D rb;
    private bool canMove=true;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        player= GameObject.FindWithTag("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void LateUpdate() {
        StartCoroutine(followPlayer()); 
    }
    IEnumerator followPlayer(){
        yield return new WaitForSeconds(waitTime);
        lookDirection = (player.transform.position-transform.position);
        if(Mathf.Abs(lookDirection.x)<0.01&&Mathf.Abs(lookDirection.y)<0.01){
            canMove=false;
        }
        else{
            canMove=true;
        }
        lookDirection.Normalize();
        if(canMove){rb.MovePosition(transform.position+(lookDirection*Time.deltaTime*speed));}
        if(lookDirection.x<0.1){
        spriteRenderer.flipX=false;
        }
        if(lookDirection.x>0.1){
        spriteRenderer.flipX=true;
        }
        
    }
   
    
}
