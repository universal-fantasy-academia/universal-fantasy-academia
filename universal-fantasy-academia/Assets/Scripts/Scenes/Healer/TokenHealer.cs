using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenHealer : MonoBehaviour
{   
    public GameObject uiIndicator;
    public TextMeshProUGUI curar;
    public bool canHeal = false;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canHeal = true;
            uiIndicator.SetActive(true);
            curar.text = "Curar";
        }
    }


    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canHeal = false; 
            uiIndicator.SetActive(false);
            curar.text = "";
        }
    }


}
