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
    
    private GameManager gameManager;
    
    private void Awake() {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        smokes[0].SetActive(true);
        if(gameManager.passedGrids.Contains(gameObject.transform.position)){
            destroySmoke();
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
        if(hasEnemy){
            gameManager.enemiesToBeSpawned=enemiesToBeSpawned;
            gameManager.enemiesToBeSpawnedLocs=enemiesToBeSpawnedLocs;
            SceneController.LoadScene(sceneToBeLoaded);
        }
    }
    
}
