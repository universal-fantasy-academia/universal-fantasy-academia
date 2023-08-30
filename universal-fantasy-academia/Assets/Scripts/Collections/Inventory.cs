using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemScriptableObject> items = new List<ItemScriptableObject>();
    private int maxItems = 10;

    public static Inventory Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Mantém o objeto mesmo quando troca de cena
        }
    }


    public void AddItem(ItemScriptableObject item)
    {
        if (items.Count >= maxItems)
        {
            Debug.Log("Inventory is full");
            
            // TODO: Avisar o jogador que o inventário está cheio

            return;
        }

        if (items.Contains(item))
        {
            item.AddQuantity();
            return;
        }

        items.Add(item);

    }

    public void RemoveItem(ItemScriptableObject item)
    {
        item.RemoveQuantity();
        if (item.quantity <= 0)
        {
            items.Remove(item);
        }
    }

    public void UseItem(ItemScriptableObject item)
    {
        item.RemoveQuantity();
        if (item.quantity <= 0)
        {
            RemoveItem(item);
        }

        item.Use();

    }


}
