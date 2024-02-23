using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameMemento
{
    public SerializableVector3 playerPosition;
    public float playerHealth;
    public int playerXP;
    // Outras propriedades do jogador

    public List<ItemScriptableObject> inventoryItems; // Lista de itens no inventário

    // Construtor para criar um memento com o estado atual
    public GameMemento(/*Vector3 position, float health, int xp, List<ItemScriptableObject> items*/)
    {
        // this.playerPosition = new SerializableVector3(position);
        // this.playerHealth = health;
        // this.playerXP = xp;
        // this.inventoryItems = items;
    }

    public void AddPlayerInfo(Vector3 position, float health, int xp)
    {
        this.playerPosition = new SerializableVector3(position);
        this.playerHealth = health;
        this.playerXP = xp;
    }

    public void AddInventoryItems(List<ItemScriptableObject> items)
    {
        this.inventoryItems = items;
    }

}
