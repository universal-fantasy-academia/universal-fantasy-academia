using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerInteraction : Interactable
{
    private Player player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnEnable()
    {
        interactDelegate += OnHealer;
    }

    public void OnHealer()
    {

        if(PlayerPrefs.GetInt("HP") < 100)
        {
            Debug.Log("Curando..."+ PlayerPrefs.GetInt("HP"));
            player.Heal(100);
        }
    }

    void OnDisable()
    {
        interactDelegate -= OnHealer;
    }

}
