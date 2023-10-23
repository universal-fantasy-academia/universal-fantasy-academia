using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private GameObject enemy;
    private Transform player;
    public float speed, timeOnDestroy;


    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Fantasma");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        ShotDirection();
        Destroy(gameObject, timeOnDestroy);
    }

    void ShotDirection()
    {
        if(enemy != null)
        {
            Vector3 dir = enemy.transform.position - transform.position;

            transform.position += dir * Time.deltaTime * speed;
        }
        else
        {
            Vector3 dir = player.forward;

            transform.position += dir * Time.deltaTime * speed;
        }
    }

}