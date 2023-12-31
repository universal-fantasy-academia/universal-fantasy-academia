using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Game Items/Consumable")]
public class ItemScriptableObjectConsumable : ItemScriptableObject
{
    public enum ConsumableType
    {
        Health,
        Mana,
        Stamina,
        Money,
        Experience,
        Key
    }

    public ConsumableType consumableType;

    public override bool Use(Player playerScript)
    {
        if (consumableType == ConsumableType.Health)
        {
            playerScript.Heal(Value);
        }
        else if (consumableType == ConsumableType.Experience)
        {
            playerScript.LevelUp(Value);
        }
        else if (consumableType == ConsumableType.Money)
        {
            playerScript.AddMoney(Value);
        }
        else if (consumableType == ConsumableType.Key)
        {
            Debug.Log("Key locked");
        }
        else
        {
            Debug.Log("Consumable type not implemented");
        }

        return true;
    }
}
