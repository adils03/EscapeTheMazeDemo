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
        if(health<healthAmount){
            healthbar.SetActive(true);
        }
    }
    void updateBar(){
        localScale.x=health/200;
        healthbar.transform.localScale=localScale;
    }
    public void takeDamage(float damage){
        health-=damage;
    }
    public void heal(float heal){
        health+=heal;
    }
    
}
