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
[Header("Consumable Item Amount")]
public int foodAmount;
public int waterAmount;
public int healthAmount;
public int sanityAmount;
public int fireFuelAmount;
public int sleepAmount;
}
public enum itemType{
    Tool,
    Weapon,
    Food,
    Water,
    Health,
    Sanity,
    FireFuel,
    Sleep

}
public enum ActionType{
    Attack,
    Use,
    Consume
}