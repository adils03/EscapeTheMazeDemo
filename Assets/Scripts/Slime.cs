using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
   [SerializeField] GameObject onDestroySpawn;
   [SerializeField] Vector3[] offsets = new Vector3[3];
   [SerializeField] Vector3 position;
   private Spawner spawner;
   private GameObject[] slimes;
   private float speed_=10;
   private new void Awake() {
    base.Awake();
    spawner=GameObject.Find("Spawner").GetComponent<Spawner>();
   }
   private void Update() {
    position=transform.position;
    offsets[0]=position+new Vector3(0.3f,0.3f,0);
    offsets[1]=position+new Vector3(0.3f,0,0);
    offsets[2]=position+new Vector3(0,0.3f,0);
   }
   private void OnDestroy() {
    for (int i = 0; i < offsets.Length; i++)
    {
        GameObject obj = Instantiate(onDestroySpawn,offsets[i],Quaternion.identity);
        obj.GetComponent<Enemy>().setSpeed(speed_);
        spawner.enemies.Add(obj);
        speed_--;
        
    }
   }
}
