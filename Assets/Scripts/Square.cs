using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private void OnMouseOver() {
        gameObject.transform.localScale=new Vector3(1,1,1);
    }
   private void OnMouseExit() {
        gameObject.transform.localScale=new Vector3(0.9f,0.9f,0.9f);
   }
}
