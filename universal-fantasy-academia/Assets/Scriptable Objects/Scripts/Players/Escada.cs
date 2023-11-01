using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada : Interactable
{
    public Player player;

    void Start()
    {
        interactDelegate += ActiveLadder;
    }

    public void ActiveLadder()
    {
        player.isOnLadder = true;
    }

    void OnDisable()
    {
        interactDelegate -= ActiveLadder;
    }
}
