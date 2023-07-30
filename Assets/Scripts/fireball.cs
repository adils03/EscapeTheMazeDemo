using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
[SerializeField]float speed;
[SerializeField]float damageAmount;
private GameObject player;
private Vector3 moveDirection;
private float xRange=10f;
private float yRange=10f;
private void Awake() {
    player=GameObject.FindWithTag("Player");
}
private void Start() {
    moveDirection=player.transform.position-transform.position;
    moveDirection.Normalize();
}
private void Update() {
    StartCoroutine(moveToPlayer());
}
IEnumerator moveToPlayer(){
    yield return new WaitForSeconds(0.5f);
    transform.Translate(moveDirection*Time.deltaTime*speed);
}
private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
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
