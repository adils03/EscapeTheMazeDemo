using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    private bool backpackOn=false;
    public GameObject inBackpack;
    // Start is called before the first frame update
    void Start()
    {
        inBackpack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBackpackActive(){
        backpackOn=!backpackOn;
        inBackpack.SetActive(backpackOn);
    }
}
