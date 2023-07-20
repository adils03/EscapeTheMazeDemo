using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController 
{
    public static void LoadScene(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }
    public static void Restart(){
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
