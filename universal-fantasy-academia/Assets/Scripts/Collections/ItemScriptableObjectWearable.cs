using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wearable", menuName = "Game Items/Wearable")]
public class ItemScriptableObjectWearable : ItemScriptableObject
{
    public enum WearableType
    {
        Helmet,
        Chest,
        Legs,
        Boots,
        Weapon,
        Shield
    }

    public WearableType wearableType;

    public override void Use(Player playerScript)
    {
        Debug.Log("Wearable Item");
    }
    
}
