using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// [CreateAssetMenu(fileName = "New Item", menuName = "Game Items/New Item", order = 1)]
public abstract class ItemScriptableObject : ScriptableObject
{
    [NonSerialized]
    public GameObject InventorySlot;
    public Sprite Icon;
    public string Name = "Item Name";
    [TextArea(15, 20)]
    public string Description = "Item Description";
    public int Value = 0;
    [NonSerialized]
    public int quantity = 0;
    public int maxQuantity;
    public bool isItemUsedByTheSystem = false; //If true, the item will be used by the system, not by the player 

    public abstract bool Use(Player playerScript);

    public void Collect()
    {
        Inventory.Instance.AddItem(this);
    }

    public void Drop(bool isPlayerUsingTheItem = true)
    {
        Inventory.Instance.RemoveItem(this, isPlayerUsingTheItem);
    }

    public void AddQuantity(int _quantity = 1)
    {
        if (this.quantity + _quantity > maxQuantity)
        {
            this.quantity = maxQuantity;
            return;
        }

        this.quantity += _quantity;
    }

    
    /// <summary>
    /// Removes a specified quantity from the item's current quantity.
    /// </summary>
    /// <param name="_quantity">The quantity to be removed. Default value is 1.</param>
    /// <param name="isPlayerUsingTheItem">Specifies whether the player is using the item or the system. Default value is true.</param>
    public void RemoveQuantity(int _quantity = 1, bool isPlayerUsingTheItem = true)
    {
        if (this.isItemUsedByTheSystem && isPlayerUsingTheItem)
        {
            return;
        }

        if (this.quantity - _quantity < 0)
        {
            this.quantity = 0;
            return;
        }

        this.quantity -= _quantity;
    }


    

}
