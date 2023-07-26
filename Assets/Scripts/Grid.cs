using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject[] smokes;
    [SerializeField] private int sceneToBeLoaded=0;
    [SerializeField] GameObject[] enemiesToBeSpawned;
    [SerializeField] Vector3[] enemiesToBeSpawnedLocs;
    [SerializeField]private bool hasEnemy=false;
    [SerializeField]private GameObject skull;
    private GameObject skull_;
    
    private GameManager gameManager;
    
    private void Awake() {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        if(hasEnemy&&!gameManager.enemyGrids.Contains(gameObject.transform.position)){
            skull_=Instantiate(skull,transform.position,Quaternion.identity);
        }
        smokes[0].SetActive(true);
        if(gameManager.passedGrids.Contains(gameObject.transform.position)){
            destroySmoke();
        }
    }
    private void Update() {
        if(!hasEnemy){
            Destroy(skull_);
        }
    }


    public void destroySmoke(){
        if(smokes!=null){
            for (int i = 0; i < smokes.Length; i++)
            {
                if(smokes[i]!=null){
                    smokes[i].GetComponent<Animation>().Play("smoke");
                }
                if(!gameManager.passedGrids.Contains(gameObject.transform.position)){
                    gameManager.passedGrids.Add(gameObject.transform.position);
                }
            }
            StartCoroutine(destroySmokes());
        }
    }

    IEnumerator destroySmokes(){
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < smokes.Length; i++)
            {
                Destroy(smokes[i]);
            }
        if(hasEnemy&&!gameManager.enemyGrids.Contains(gameObject.transform.position)){
            gameManager.gridNow=gameObject.transform.position;
            gameManager.enemiesToBeSpawned=enemiesToBeSpawned;
            gameManager.enemiesToBeSpawnedLocs=enemiesToBeSpawnedLocs;
            SceneController.LoadScene(sceneToBeLoaded);
        }
    }
    
}
