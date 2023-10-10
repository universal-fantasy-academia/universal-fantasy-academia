using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class BombTest : MonoBehaviour
{
    public AudioSource initialSound;
    public AudioSource explodionSound;
    public GameObject player;
    public float speed = 2 , rotation;
    private Transform transformEnemy;
    public int life = 2;
    public int minMagnitude;

    void Awake()
    {
        transformEnemy = GetComponent<Transform>();
    }


    void FixedUpdate()
    {

        Vector3 dir;
        dir = player.transform.position - transformEnemy.position;

        float m = dir.magnitude;

        if(m < minMagnitude)
        {
            transformEnemy.position += dir * Time.fixedDeltaTime * speed;
            if(dir != Vector3.zero)
            {
                transformEnemy.forward = Vector3.Slerp(transformEnemy.forward, dir.normalized, Time.fixedDeltaTime * rotation);
            }
            //Invoke(nameof(DeathGhost), 10f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DeathGhost();
        }

        if(other.CompareTag("Weapon"))
        {
            Destroy(other);
            life--;
            if(life <= 0)
            {
                DeathGhost();
            }
        }
    }

    void DeathGhost()
    {
        explodionSound.Play();
        Destroy(gameObject);
    }

}
