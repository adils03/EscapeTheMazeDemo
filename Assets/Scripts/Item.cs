using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO Item")]
public class Item : ScriptableObject
{

[Header("Only Gameplay")]
public ActionType actionType;
public itemType itemType;
public Vector2Int range= new Vector2Int(5,4);

[Header("Only UI")]
public bool stackable=true;
public bool consumable;

[Header("Both")]
public Sprite image;
}
public enum itemType{
    Axe,
    Pickaxe,
    Shovel,
    IronKey,
    Heart,
    GoldenKey

}
public enum ActionType{
    Attack,
}