using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {
    public Transform door;
    private GameObject player;
    public AudioSource soundDoor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void UseDoor()
    {
        CharacterController controller = player.GetComponentInParent<CharacterController>();

        controller.enabled = false;


        player.transform.position = new Vector3(door.position.x, door.position.y, door.position.z);
        player.transform.forward = door.forward;
        if (soundDoor != null)
            soundDoor.Play();

        controller.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            UseDoor();
            Debug.Log("Escada");
        }
    }

}
