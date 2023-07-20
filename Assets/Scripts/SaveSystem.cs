using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveSystem : MonoBehaviour
{
    public List<GameObject> destroyedSmokes;
    public GameObject playerPosition;
    public void SaveToJson(){
        GameData data = new GameData();
        data.playerPosition = playerPosition.transform.position;
        for (int i = 0; i < destroyedSmokes.Count; i++)
        {
            data.destroyedSmokes[i]=destroyedSmokes[i].transform.position;
        }
        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath+"/savefile.json",json);
    }
    public void LoadFromJson(){
        string json = File.ReadAllText(Application.dataPath+"savefile.json");
    }
}
