using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour
{
    public GameObject[] Enemys;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i = 0; i < 10 ;i++)
            {
                Enemys[i].SetActive(true);
            }
        }
    }
}
