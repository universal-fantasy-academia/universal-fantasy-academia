using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada : Interactable
{
    public Player player;
    public Transform transformPlayer, transformEscada;
    public bool onLadder = false;

    void Start()
    {
        if(onLadder == false)
        {
            interactDelegate += ActiveLadder;
        }
        if(onLadder == true)
        {
            interactDelegate += DisableLadder;
        }
    }

    public void ActiveLadder()
    {
        onLadder = true;
        player.isOnLadder = true;
        transformPlayer.position = transformEscada.position;
        transformPlayer.rotation = transformEscada.rotation;
        Debug.Log(onLadder);
    }

    public void DisableLadder()
    {
        onLadder = false;
        player.isOnLadder = false;
        Debug.Log(onLadder);
    }

    void OnDisable()
    {
        if(onLadder)
        {
            interactDelegate -= ActiveLadder;
        }
        if(!onLadder)
        {
            interactDelegate -= DisableLadder;
        }
    }
}
