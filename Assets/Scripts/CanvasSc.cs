using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSc : MonoBehaviour
{
private static CanvasSc canvasSc;
 private void Awake() {
    DontDestroyOnLoad(this);
    if(canvasSc==null){
        canvasSc=this;
    }else {
        Destroy(gameObject);
    }
 }
}
