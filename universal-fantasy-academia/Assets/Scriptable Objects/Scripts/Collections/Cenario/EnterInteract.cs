using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterInteract : Interactable
{
    public Transform door;
    private GameObject player;
    public AudioSource soundDoor;


    // void Awake()
    // {
    //     player = GameObject.FindGameObjectWithTag("Player");
    // }

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        interactDelegate += UseDoor;
    }

    public void UseDoor()
    {
        CharacterController controller = player.GetComponentInParent<CharacterController>();

        controller.enabled = false;


        player.transform.position = new Vector3(door.position.x, door.position.y, door.position.z);
        player.transform.forward = door.forward;
        if(soundDoor != null)
        soundDoor.Play();

        controller.enabled = true;
    }

    void OnDisable()
    {
        interactDelegate -= UseDoor;
    }
}
