using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{ 
    [Header("Bars")]
    public Slider healthBar;
    public Slider hungerBar;
    public Slider waterBar;
    public Slider sanityBar;
    public Slider sleepBar;
    public Slider fireBar;
    [Header("Counters")]
    public float fireCounter = 100;
    public float hungerCounter = 100;
    public float waterCounter = 100;
    public float sleepCounter = 100;
    public float healthCounter=100;
    public float sanityCounter=100;
    [Header("Multipliers")]
    [SerializeField] private float fireReduceMultiplier = 1.0f;
    [SerializeField] private float sleepReduceMultiplier = 0.1f;
    [SerializeField] private float hungerReduceMultiplier = 0.3f;
    [SerializeField] private float waterReduceMultiplier = 0.2f;
    private float tempFireCounter;
    private float tempWaterCounter;
    private float tempSleepCounter;
    private float tempHungerCounter;
    private float tempHealthCounter;
    private float tempSanityCounter;
    private void Start() {
        setTempCounters();
    }
    private void Update() {
        ReduceFireOverTime();
        ReduceHungerOverTime();
        ReduceSleepOverTime();
        ReduceWaterOverTime();
        maxController();
    }

    private void maxController(){
        if(waterCounter>tempWaterCounter){
            waterCounter=tempWaterCounter;
        }
        if(hungerCounter>tempHungerCounter){
            hungerCounter=tempHungerCounter;
        }
        if(fireCounter>tempFireCounter){
            fireCounter=tempFireCounter;
        }
        if(sleepCounter>tempSleepCounter){
            sleepCounter=tempSleepCounter;
        }
        if(healthCounter>tempHealthCounter){
            healthCounter=tempHealthCounter;
        }
        if(sanityCounter>tempSanityCounter){
            sanityCounter=tempSanityCounter;
        }
    }
    private void setTempCounters(){
        tempFireCounter=fireCounter;
        tempHungerCounter=hungerCounter;
        tempSleepCounter=sleepCounter;
        tempWaterCounter=waterCounter;
        tempHealthCounter=healthCounter;
        tempSanityCounter=sanityCounter;
    }
    private void ReduceWaterOverTime(){
        if(waterBar.value>waterBar.minValue){
            waterCounter -= waterReduceMultiplier*Time.deltaTime;
            waterBar.value=waterCounter;
        }  
    }
    private void ReduceHungerOverTime(){
        if(hungerBar.value>hungerBar.minValue){
            hungerCounter -= hungerReduceMultiplier*Time.deltaTime;
            hungerBar.value=hungerCounter;
        }
        
    }
    private void ReduceFireOverTime(){
        if(fireBar.value>fireBar.minValue){
             fireCounter -= fireReduceMultiplier*Time.deltaTime;
            fireBar.value=fireCounter;   
        }
        
    }
    private void ReduceSleepOverTime(){
        if(sleepBar.value>sleepBar.minValue){
            sleepCounter -= sleepReduceMultiplier*Time.deltaTime;
            sleepBar.value=sleepCounter;
        }
        
    }
    public  void addFire(int fireAmount){
        fireCounter += fireAmount;
        fireBar.value=fireCounter;
    }
    public void addHealth(int healthAmount){
        healthCounter+=healthAmount;
        healthBar.value=healthCounter;
    }
    public void addHunger(int hungerAmount){
        hungerCounter+=hungerAmount;
        hungerBar.value=hungerCounter;
    }
    public void addWater(int waterAmount){
        waterCounter+=waterAmount;
        waterBar.value=waterCounter;
    }
    public void addSanity(int sanityAmount){
        sanityCounter+=sanityAmount;
        sanityBar.value=sanityCounter;
    }
    public void addSleep(int sleepAmount){
        sleepCounter+=sleepAmount;
        sleepBar.value=sleepCounter;
    }
}
