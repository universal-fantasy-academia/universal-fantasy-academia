using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSensor : MonoBehaviour
{
    ArrayList items = new ArrayList();

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            items.Add();
        }
    }

}
