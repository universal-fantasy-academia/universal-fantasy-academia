using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game Items/New Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite Icon;
    public string Name = "Item Name";
    [TextArea(15, 20)]
    public string Description = "Item Description";
    public int Value = 0;
    public int quantity;
    public int maxQuantity;
    public event Action<int> OnItemUsed;

    public void Use()
    {
        OnItemUsed?.Invoke(Value);
    }

    public void Collect()
    {
        Inventory.Instance.AddItem(this);
    }

    public void Drop()
    {
        Inventory.Instance.RemoveItem(this);
    }

    public void AddQuantity(int quantity = 1)
    {
        if (this.quantity + quantity > maxQuantity)
        {
            this.quantity = maxQuantity;
            return;
        }

        this.quantity += quantity;
    }

    public void RemoveQuantity(int quantity = 1)
    {
        if (this.quantity - quantity < 0)
        {
            this.quantity = 0;
            return;
        }

        this.quantity -= quantity;
    }


    

}
