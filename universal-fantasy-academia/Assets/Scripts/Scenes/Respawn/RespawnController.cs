using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player playerScript = other.GetComponent<Player>();

            if(playerScript != null)
            {
                playerScript.respawn = gameObject.transform;
            Debug.Log("Salvando novo Respawn "+ gameObject.transform.position);
            }
        }
    }

}
