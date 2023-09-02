using System;
using System.Collections;
using System.Collections.Generic;
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

    public abstract void Use(Player playerScript);

    public void Collect()
    {
        Inventory.Instance.AddItem(this);
    }

    public void Drop()
    {
        Inventory.Instance.RemoveItem(this);
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

    public void RemoveQuantity(int _quantity = 1)
    {
        if (this.quantity - _quantity < 0)
        {
            this.quantity = 0;
            return;
        }

        this.quantity -= _quantity;
    }


    

}
