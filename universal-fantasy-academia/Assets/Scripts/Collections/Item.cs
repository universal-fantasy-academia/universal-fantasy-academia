using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public GameObject prefab;
    public Sprite icon;
    public string itemName;
    public string description;
    public int quantity;
    public int maxQuantity;

    // Start is called before the first frame update
    void Start()
    {
        // Precisa inicializar algo aqui ou somente nas classes filhas?
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



    public abstract void Use();

}