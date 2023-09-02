using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private GameObject inventoryContent;
    [SerializeField]
    private GameObject inventorySlotPrefab;
    private List<ItemScriptableObject> items = new List<ItemScriptableObject>();
    private int maxItems = 10;

    public Player playerScript;

    public static Inventory Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o objeto mesmo quando troca de cena
        }
    }


    public void AddItem(ItemScriptableObject item)
    {
        if (items.Count >= maxItems)
        {
            Debug.Log("Inventory is full");
            
            // TODO: Avisar o jogador que o inventário está cheio
            Debug.Log("Inventory is full");

            return;
        }

        if (items.Contains(item))
        {
            item.AddQuantity();
            item.InventorySlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.quantity.ToString();
            return;
        }

        item.AddQuantity();

        //Add child to content
        GameObject iventorySlot = Instantiate(inventorySlotPrefab, inventoryContent.transform);
        //Change button icon
        iventorySlot.transform.GetChild(0).GetComponent<Image>().sprite = item.Icon;
        //Change button text mesh pro
        iventorySlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.quantity.ToString();
        //Associate OnClick event
        iventorySlot.GetComponent<Button>().onClick.AddListener(() => UseItem(item));

        item.InventorySlot = iventorySlot;
        items.Add(item);
        
    }

    public void RemoveItem(ItemScriptableObject item)
    {
        item.RemoveQuantity();
        if (item.quantity <= 0)
        {
            items.Remove(item);
            Destroy(item.InventorySlot);
        }
        item.InventorySlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.quantity.ToString();
    }

    public void UseItem(ItemScriptableObject item)
    {
        item.RemoveQuantity();
        if (item.quantity <= 0)
        {
            RemoveItem(item);
        }
        item.InventorySlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.quantity.ToString();

        item.Use(playerScript);
    }


}
