using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private Vector3 forcedirection;
    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(followPlayer());
    }

    IEnumerator followPlayer(){
        yield return new WaitForSeconds(2f);
        Vector3 lookDirection = (player.transform.position-transform.position);
        lookDirection.Normalize();
        forcedirection=lookDirection;
        rb.MovePosition(transform.position+(lookDirection*Time.deltaTime*speed));
        if(lookDirection.x<0){
        transform.rotation=new Quaternion(0,0,0,0);
        }
        if(lookDirection.x>0){
        transform.rotation=new Quaternion(0,180,0,0);
        }
    }
    //bakılacak
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.gameObject.tag=="Player"){
            Debug.Log("player");
            player.transform.Translate(forcedirection/2);
        }
    }
    
}
