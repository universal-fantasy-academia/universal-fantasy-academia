using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryDoor : Interactable
{
    private GameObject player;
    public AudioSource soundDoor;
    public GameObject door;
    
    Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
        interactDelegate += UseDoor;
    }

    public void UseDoor()
    {
        soundDoor.Play();
        if (CheckInventory())
        {
            door.SetActive(false);
            interactDelegate -= UseDoor;

            ItemScriptableObject item = inventory.GetItem("Key");
            inventory.RemoveItem(item, false);
        }
        else
        {
            Debug.Log("You don't have the key");
        }
    }

    bool CheckInventory()
    {
        if (inventory.ContainsItem("Key"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnDisable()
    {
        interactDelegate -= UseDoor;
    }
}
