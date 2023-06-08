using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthAmount;
    private Vector3 localScale;
    private GameObject healthbar;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health=healthAmount;
        healthbar = transform.GetChild(0).gameObject;
        localScale=healthbar.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            takeDamage(10);
        }
        checkHealth();
        updateBar();
    }
    void checkHealth(){
        if(health>healthAmount){
            health=healthAmount;
        }
        if(health<=0){
            Destroy(gameObject);
        }
    }
    void updateBar(){
        localScale.x=health/200;
        healthbar.transform.localScale=localScale;
    }
    void takeDamage(int damage){
        health-=damage;
    }
    void heal(int heal){
        health+=heal;
    }
    
}
