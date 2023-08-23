using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private int maxItems = 10;
    private int currentItems = 0;
    private int currentSelectedIndex = 0;
    private Item currentItem;

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


    public void AddItem(Item item)
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

    public void RemoveItem(Item item)
    {
        item.RemoveQuantity();
        if (item.quantity <= 0)
        {
            items.Remove(item);
        }
    }

    public void UseItem(Item item)
    {
        item.RemoveQuantity();
        if (item.quantity <= 0)
        {
            RemoveItem(item);
        }

        item.Use();

    }


}
