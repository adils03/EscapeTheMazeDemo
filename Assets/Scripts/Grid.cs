using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject[] smokes;
    void Start()
    {
        smokes[0].SetActive(true);
    }


    public void destroySmoke(){
        if(smokes!=null){
            for (int i = 0; i < smokes.Length; i++)
            {
                smokes[i].GetComponent<Animation>().Play("smoke");
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
    }
    
}
