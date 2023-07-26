using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackLocation : MonoBehaviour
{
[SerializeField]private GameObject player;
private void Awake() {
    player=GameObject.Find("PlayerMaze");
}
private void Update() {
    player=GameObject.Find("PlayerMaze");
    locationFixer();
}
void locationFixer(){
    if(player.transform.position.x>=-14&&player.transform.position.x<=-12&&player.transform.position.y<=-2.8&&player.transform.position.y>=-3.2){
        GetComponent<RectTransform>().anchoredPosition = new Vector2(640, 94);
    }
    else{
        GetComponent<RectTransform>().anchoredPosition = new Vector2(27, 94);
    }
}
}
