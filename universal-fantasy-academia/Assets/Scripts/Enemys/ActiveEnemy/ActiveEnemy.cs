using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour
{
    public GameObject[] Enemys;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && Enemys != null)
        {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    Enemys[i].SetActive(true);
                }
        }
    }
}
