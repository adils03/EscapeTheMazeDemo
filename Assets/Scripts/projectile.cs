using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damageAmount;
    private float xRange=10f;
    private float yRange=10f;
    void Update()
    {
        shot();
       keepBounds();
    }

    void shot() {
       transform.Translate(new Vector3(1,0,0)*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            other.gameObject.GetComponent<Health>().takeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
    void keepBounds(){
        if(transform.position.x>xRange||transform.position.x<-xRange||transform.position.y>yRange||transform.position.y<-yRange){
            Destroy(gameObject);
        }
    }
    
}
