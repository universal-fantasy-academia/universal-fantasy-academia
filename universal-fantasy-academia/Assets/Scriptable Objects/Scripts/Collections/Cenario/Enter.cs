using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : Interactable
{
    public Transform door;
    private GameObject player;
    public AudioSource soundDoor;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        interactDelegate += UseDoor;
    }

    public void UseDoor()
    {
        player.transform.position = door.position;
        player.transform.forward = door.forward;
        soundDoor.Play();
    }

    void OnDisable()
    {
        interactDelegate -= UseDoor;
    }
}
